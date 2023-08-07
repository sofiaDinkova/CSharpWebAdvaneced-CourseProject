using Blasco.Data;
using Blasco.Data.Models;

using Blasco.Services.Data.Interfaces;
using Blasco.Services.Data.Models.Product;
using Blasco.Services.Data.Models.Statistics;
using Blasco.Web.ViewModels.Challenge;
using Blasco.Web.ViewModels.Home;
using Blasco.Web.ViewModels.Product;
using Blasco.Web.ViewModels.Product.Enums;
using Microsoft.EntityFrameworkCore;

namespace Blasco.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly BlascoDbContext dbContext;
        private readonly IImageService imageService;

        public ProductService(BlascoDbContext dbContext, IImageService imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeProductAsync()
        {
            IEnumerable<IndexViewModel> lastThreeProducts = await this.dbContext
                .Products
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.CreatedOn)
                .Take(3)
                .Select(p => new IndexViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    ImageArray = imageService.GetImageBytesByEntityCorrespondingId(p.Id.ToString())
                })
                .ToArrayAsync();

            return lastThreeProducts;
        }
        public async Task<string> CreateAndReturnIdAsync(ProductFormModel formModel, string creatorId)
        {
            Guid id = Guid.NewGuid();
            Product product = new Product
            {
                Id = id,
                Title = formModel.Title,
                Description = formModel.Description,
                Price = formModel.Price,
                CategoryId = formModel.CategoryId,
                CreatorId = Guid.Parse(creatorId),
                City = formModel.City,
            };

            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();

            await this.imageService.InsertImagesAsync(formModel.Images, id.ToString());

            return id.ToString();
        }

        public async Task<AllProductsFilteredAndPagedModel> AllAsync(AllProductsQueryModel queryModel)
        {
            IQueryable<Product> productQuery = this.dbContext
                .Products
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                productQuery = productQuery
                    .Where(p => p.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                productQuery = productQuery
                    .Where(p => EF.Functions.Like(p.Title, wildCard) ||
                              EF.Functions.Like(p.Description, wildCard));
            }

            productQuery = queryModel.ProductSorting switch
            {
                ProductSorting.Newest => productQuery
                     .OrderByDescending(p => p.CreatedOn),
                ProductSorting.Oldest => productQuery
                    .OrderBy(p => p.CreatedOn),
                ProductSorting.PriceAscending => productQuery
                    .OrderBy(p => p.Price),
                ProductSorting.PriceDescending => productQuery
                    .OrderByDescending(p => p.Price),
                _ => productQuery
                    .OrderBy(p => p.CustomerId == null)
                    .ThenByDescending(p => p.CreatedOn)
            };

            IEnumerable<ProductAllViewModel> allProducts = await productQuery
                .Where(p => p.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.ProductsPerPage)
                .Take(queryModel.ProductsPerPage)
                .Select(p => new ProductAllViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    City = p.City,
                    Price = p.Price,
                    IsPurchased = p.CustomerId.HasValue,
                })
                .ToArrayAsync();
            int totalProducts = productQuery.Count();
            foreach (var product in allProducts)
            {
                List<byte[]> biteImg = imageService.GetAllImagesBytesByEntityCorrespondingId(product.Id);
                product.ImagesArray = biteImg;
            }

            return new AllProductsFilteredAndPagedModel()
            {
                TotalProductsCount = totalProducts,
                Products = allProducts
            };
        }

        public async Task<IEnumerable<ProductAllViewModel>> AllByCustomerIdAsync(string customerId)
        {
            IEnumerable<ProductAllViewModel> allCustomerProducts = await this.dbContext
                .Products
                .Where(p => p.IsActive && p.CustomerId.HasValue && p.CustomerId.ToString() == customerId)
                .Select(p => new ProductAllViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Price = p.Price,
                    City = p.City,
                    IsPurchased = p.CustomerId.HasValue
                })
                .ToArrayAsync();

            return allCustomerProducts;
        }

        public async Task<IEnumerable<ProductAllViewModel>> AllByCreatorIdAsync(string creatorId)
        {
            IEnumerable<ProductAllViewModel> allCreatorProducts = await this.dbContext
                .Products
                .Where(p => p.IsActive && p.CreatorId.ToString() == creatorId)
                .Select(p => new ProductAllViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Price = p.Price,
                    City = p.City,
                    IsPurchased = p.CustomerId.HasValue
                })
                .ToArrayAsync();

            return allCreatorProducts;
        }

        public async Task<ProductDetailsViewModel> GetDetailsByIdAsync(string productId)
        {
            Product product = await this.dbContext
                .Products
                .Include(p => p.Category)
                .Include(p => p.Creator)
                .Where(p => p.IsActive)
                .FirstAsync(h => h.Id.ToString() == productId);

            string creatorEmail = product.Creator.Email;
            string creatorPseudonym = product.Creator.UserName;

            return new ProductDetailsViewModel
            {
                Id = product.Id.ToString(),
                Title = product.Title,
                Price = product.Price,
                IsPurchased = product.CustomerId.HasValue,
                Description = product.Description,
                Category = product.Category.Name,
                CreatorId = product.CreatorId.ToString(),
                CreatorEmail = creatorEmail,
                CreatorPseudonym = creatorPseudonym,
            };
        }

        public async Task<bool> ExistsByIdAsync(string productId)
        {
            bool result = await this.dbContext
                .Products
                .Where(p => p.IsActive)
                .AnyAsync(p => p.Id.ToString() == productId);

            return result;
        }

        public async Task<ProductFormModel> GetProductForEditByIdAsync(string productId)
        {
            Product product = await this.dbContext
                .Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .FirstAsync(h => h.Id.ToString() == productId);

            return new ProductFormModel
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                City = product.City,
                CategoryId = product.CategoryId
            };
        }

        public async Task<bool> IsCreatorWithIdOwnerOfProductWithIdAsync(string productId, string creatorId)
        {
            Product product = await this.dbContext
                .Products
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == productId);

            return product.CreatorId.ToString() == creatorId;
        }

        public async Task EditProductByIdAndFormModelAsync(string productId, ProductFormModel formModel)
        {
            Product product = await this.dbContext
                .Products
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == productId);

            product.Title = formModel.Title;
            product.Description = formModel.Description;
            product.Price = formModel.Price;
            product.City = formModel.City;
            product.CategoryId = formModel.CategoryId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ProductPreDeleteDetailsViewModel> GetProductForDeleteByIdAsync(string productId)
        {
            Product product = await this.dbContext
            .Products
            .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == productId);

            return new ProductPreDeleteDetailsViewModel
            {
                Title = product.Title,
                Price = product.Price,
            };
        }

        public async Task DeleteProductByIdAsync(string id)
        {
            Product productToDelete = await this.dbContext
            .Products
            .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == id);

            productToDelete.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsPurchasedByIdAsync(string productId)
        {
            Product product = await this.dbContext
                .Products
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == productId);

            return product.CustomerId.HasValue;
        }

        public async Task PuchaseProductAsync(string productId, string userId)
        {
            Product product = await this.dbContext
                 .Products
                 .Where(p => p.IsActive)
                 .FirstAsync(p => p.Id.ToString() == productId);

            product.CustomerId = Guid.Parse(userId);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> isPurchesedByCustomerWithIdAsync(string productId, string customerId)
        {
            Product product = await this.dbContext
                .Products
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == productId);

            return product.CustomerId.HasValue && product.CustomerId.ToString() == customerId;
        }

        public async Task CancelProductAsync(string productId, string customerId)
        {
            Product product = await this.dbContext
                .Products
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == productId);

            product.CustomerId = null;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<StatisticsServiceModel> GetStatisticsAsync()
        {
            return new StatisticsServiceModel()
            {
                TotalProducts = await this.dbContext.Products.CountAsync(),
                TotalPurchesedProducts = await this.dbContext.Products
                    .Where(p => p.CustomerId.HasValue)
                    .CountAsync()
            };
        }
    }
}