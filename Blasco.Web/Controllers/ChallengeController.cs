namespace Blasco.Web.Controllers
{
    using Blasco.Web.Infrastructure.Extentions;
    using Blasco.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using ViewModels.Challenge;

    using static Common.NotificationMessagesConstents;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class ChallengeController : Controller
    {
        private readonly IChallengeService challengeService;
        private readonly IProductProjectCategoryService productProjectCategoryService;


        public ChallengeController(IChallengeService challengeService, IProductProjectCategoryService productProjectCategoryService)
        {
            this.challengeService = challengeService;
            this.productProjectCategoryService = productProjectCategoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllChallenges()
        {
            try
            {
                AllChallengesModel viewModel = await this.challengeService.AllChallengesAsync();

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                if (this.User.IsCreator())
                {
                    this.TempData[ErrorMessage] = "You must be a customer to add new challenges";
                    return this.RedirectToAction("Home", "Index");
                }

                ChallengeFormModel formModel = new ChallengeFormModel()
                {
                    ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ChallengeFormModel model)
        {
            if (this.User.IsCreator())
            {
                this.TempData[ErrorMessage] = "You must be a customer to add new challenges";
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
                string customerId = User.GetId()!;
                string challengetId = await this.challengeService.CreateAndReturnIdAsync(model, customerId);

                this.TempData[SuccessMessage] = "Challenge was added successfully";

                return this.RedirectToAction("AllChallenges", "Challenge", new { id = challengetId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();

                return this.View(model);
            }
        }
    }
}
