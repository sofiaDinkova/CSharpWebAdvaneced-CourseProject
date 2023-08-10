﻿namespace Blasco.Web.Controllers
{
    using Blasco.Services.Data.Interfaces;
    using Blasco.Services.Data.Models.Product;
    using Blasco.Web.Infrastructure.Extentions;
    using Blasco.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationMessagesConstents;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductProjectCategoryService productProjectCategoryService;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        private readonly ICreatorService creatorService;
        private readonly IImageService imageService;

        public ProductController(IProductProjectCategoryService productProjectCategoryService, ICustomerService customerService, IProductService productService, ICreatorService creatorService, IImageService imageService)
        {
            this.productProjectCategoryService = productProjectCategoryService;
            this.customerService = customerService;
            this.productService = productService;
            this.creatorService = creatorService;
            this.imageService = imageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllProducts([FromQuery] AllProductsQueryModel queryModel)
        {
            try
            {
                AllProductsFilteredAndPagedModel serviceModel = await this.productService.AllAsync(queryModel);

                queryModel.Products = serviceModel.Products;
                queryModel.TotalProducts = serviceModel.TotalProductsCount;
                queryModel.Categories = await this.productProjectCategoryService.AllProductProjectCategoryNamesAsync();

                return this.View(queryModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                if (this.User.IsCustomer())
                {
                    this.TempData[ErrorMessage] = "You must be a creator to add new Products";
                    return this.RedirectToAction("Home", "Index");
                }

                ProductAddFormModel formModel = new ProductAddFormModel()
                {
                    ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddFormModel model)
        {
            if (this.User.IsCustomer())
            {
                this.TempData[ErrorMessage] = "You must be a creator to add new Products";
                return this.RedirectToAction("Home", "Index");
            }

            bool categoryExist = await this.productProjectCategoryService.ExsistsByIdAsync(model.CategoryId);
            if (!categoryExist)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist");
            }

            if (!this.ModelState.IsValid)
            {
                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();

                return this.View(model);
            }

            try
            {
                string creatorId = User.GetId()!;
                string productId = await this.productService.CreateAndReturnIdAsync(model, creatorId);

                this.TempData[SuccessMessage] = "Product was added successfully";

                return this.RedirectToAction("Details", "Product", new { id = productId});
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();

                return this.View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided ID does not exist";
                return this.RedirectToAction("AllProducts", "Product");
            }

            
            if (this.User.IsCustomer() && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be Creator to delete Products";
                return this.RedirectToAction("AllProducts", "Product");
            }

            
            bool isCreatorOwner = await this.productService
                .IsCreatorWithIdOwnerOfProductWithIdAsync(id, this.User.GetId()!);

            if (!isCreatorOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Creator owner to the Product in order to edit it.";
                return this.RedirectToAction("Mine", "Product");
            }

            try
            {
                ProductPreDeleteDetailsViewModel viewmodel = await this.productService.GetProductForDeleteByIdAsync(id);

                return this.View(viewmodel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductPreDeleteDetailsViewModel model)
        {
            bool productExists = await productService.ExistsByIdAsync(model.Id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided ID does not exist";
                return this.RedirectToAction("AllProducts", "Product");
            }

            
            if (this.User.IsCustomer() && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be Creator to delete Products";
                return this.RedirectToAction("AllProducts", "Product");
            }

            string creatorId = this.User.GetId()!;

            bool isCreatorOwner = await this.productService
                .IsCreatorWithIdOwnerOfProductWithIdAsync(model.Id, creatorId!);

            if (!isCreatorOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Creator of the Product to delete it";
                return this.RedirectToAction("AllProducts", "Product");
            }

            try
            {
                await this.imageService.DeleteProductImagesByEntityCorrespondingIdAsync(model.Id);
                await this.productService.DeleteProductByIdAsync(model.Id);

                this.TempData[WarningMessage] = "The Product was successfully deleted";
                return this.RedirectToAction("Mine", "Product");
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<ProductAllViewModel> myProducts = new List<ProductAllViewModel>();

            try
            {
                string userId = this.User.GetId()!;

                bool isUserCustomer = await this.customerService.CustomerExistsByCreatorId(userId);

                //if (this.User.IsAdmin())
                //{
                //    string customerId = await this.customerService.GetCustomerByUserIdAsync(userId);
                //    //purchased Product as customer
                //    myProducts.AddRange(await this.productService.AllByCustomerIdAsync(customerId));
                //    //added Product as creator
                //    myProducts.AddRange(await this.productService.AllByCreatorIdAsync(userId));

                //    //preventing doubles(Products)
                //    myProducts = myProducts
                //        .DistinctBy(p => p.Id)
                //        .ToList();
                //}
                if (this.User.IsCustomer())
                {
                    myProducts.AddRange(await this.productService.AllByCustomerIdAsync(userId));
                }
                else if(this.User.IsCreator())
                {
                    myProducts.AddRange(await this.productService.AllByCreatorIdAsync(userId));
                }
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            return this.View(myProducts);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided ID does not exist";
                return this.RedirectToAction("AllProducts", "Product");
            }

            try
            {
                ProductDetailsViewModel viewModel = await this.productService
                 .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided ID does not exist";
                return this.RedirectToAction("AllProducts", "Product");
            }

            if (this.User.IsCustomer() && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be Creator to edit Products";
                return this.RedirectToAction("AllProducts", "Product");
            }

            bool isCreatorOwner = await this.productService
                .IsCreatorWithIdOwnerOfProductWithIdAsync(id, this.User.GetId()!);

            if (!isCreatorOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Creator owner to the Product in order to edit it.";
                return this.RedirectToAction("Mine", "Product");
            }

            try
            {
                ProductEditFormModel formModel = await this.productService
                .GetProductForEditByIdAsync(id);
                formModel.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ProductEditFormModel model)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            

            if (!this.ModelState.IsValid)
            {
                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();
                return this.View(model);
            }

            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided ID does not exist";
                return this.RedirectToAction("AllProducts", "Product");
            }

            if (this.User.IsCustomer() && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be Creator to edit Products";
                return this.RedirectToAction("AllProducts", "Product");
            }

            bool isCreatorOwner = await this.creatorService.HasProductWithIdAsync(id, this.User.GetId()!);

            if (!isCreatorOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Creator owner to the Product in order to edit it.";
                return this.RedirectToAction("Mine", "Product");
            }

            try
            {
                await this.productService.EditProductByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while saving your changes! Please try again letar or contact an administrator.");

                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();
                return this.View(model);

            }

            this.TempData[SuccessMessage] = "Product was edited successfully";

            return this.RedirectToAction("Details", "Product", new { id = id });
        }

        

        [HttpPost]
        public async Task<IActionResult> PurchaseProduct(string id)
        {
            bool productExists = await this.productService.ExistsByIdAsync(id);
            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided ID does not exist";
                return this.RedirectToAction("AllProducts", "Product");
            }

            bool isPurcherchesed = await this.productService.IsPurchasedByIdAsync(id);
            if (isPurcherchesed)
            {
                this.TempData[ErrorMessage] = "Product is allready purchesed";
                return this.RedirectToAction("AllProducts", "Product");
            }

            //TODO: change ProductEntity to have Buyer instead of Customer; Change logic so that creators can also buy Products!
            //string userId = this.User.GetId()!;

            //bool isTheCreatorOfTheProductTheUser = await this.productService.IsCreatorWithIdOwnerOfProductWithIdAsync(id, userId);

            //if (isTheCreatorOfTheProductTheUser)
            //{
            //    this.TempData[ErrorMessage] = "Creators of products can not purchase their own products!";
            //    return this.RedirectToAction("AllProducts", "Product");
            //}

            bool isCustomer = await this.customerService.CustomerExistsByCreatorId(this.User.GetId()!);

            if (!isCustomer && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be a customer to purchase Products";
                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                string customerId = await this.customerService.GetCustomerByUserIdAsync(this.User.GetId());
                await this.productService.PuchaseProductAsync(id, customerId);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            this.TempData[SuccessMessage] = "Product was purchased successfully";
            return this.RedirectToAction("Mine", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> CancelProduct(string id)
        {
            bool productExists = await this.productService.ExistsByIdAsync(id);
            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Product with the provided ID does not exist";
                return this.RedirectToAction("AllProducts", "Product");
            }

            bool isPurcherchesed = await this.productService.IsPurchasedByIdAsync(id);
            if (!isPurcherchesed)
            {
                this.TempData[ErrorMessage] = "Product is not purchesed";
                return this.RedirectToAction("Mine", "Product");
            }

            string customerId = await this.customerService.GetCustomerByUserIdAsync(this.User.GetId());

            bool didTheCurrCustomerPurchaseTheProduct = await this.productService.isPurchesedByCustomerWithIdAsync(id, customerId);

            if (!didTheCurrCustomerPurchaseTheProduct)
            {
                this.TempData[ErrorMessage] = "Product is not purchesed by you";
                return this.RedirectToAction("Mine", "Product");
            }

            try
            {
                await this.productService.CancelProductAsync(id, customerId);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            this.TempData[SuccessMessage] = "Product was canceled successfully";
            return this.RedirectToAction("Mine", "Product");
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again letar or contact an administrator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
