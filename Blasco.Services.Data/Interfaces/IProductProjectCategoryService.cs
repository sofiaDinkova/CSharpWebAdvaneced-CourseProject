using Blasco.Web.ViewModels.ProductProjectCategory;

namespace Blasco.Services.Data.Interfaces
{
    public interface IProductProjectCategoryService
    {
        Task<IEnumerable<ProductSelectCategoryFormModel>> AllProductProjectCategoryAsync();

        Task<bool> ExsistsByIdAsync(int id);

        Task<IEnumerable<string>> AllProductProjectCategoryNamesAsync();
    }
}
