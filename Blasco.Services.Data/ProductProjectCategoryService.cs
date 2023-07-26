using Blasco.Data;
using Blasco.Services.Data.Interfaces;
using Blasco.Web.ViewModels.ProductProjectCategory;
using Microsoft.EntityFrameworkCore;

namespace Blasco.Services.Data
{
    public class ProductProjectCategoryService : IProductProjectCategoryService
    {
        private readonly BlascoDbContext dbContext;
        public ProductProjectCategoryService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductSelectCategoryFormModel>> AllProductProjectCategoryAsync()
        {
            IEnumerable<ProductSelectCategoryFormModel> allProductProjectCategories = await this.dbContext
                .ProductProjectCategories
                .AsNoTracking()
                .Select(c => new ProductSelectCategoryFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allProductProjectCategories;
        }


        public async Task<bool> ExsistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .ProductProjectCategories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<string>> AllProductProjectCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .ProductProjectCategories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }
    }
}
