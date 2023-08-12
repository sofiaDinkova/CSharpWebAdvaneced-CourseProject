namespace Blasco.Services.Data.Interfaces
{
    using Web.ViewModels.ProductProjectCategory;

    public interface IProductProjectCategoryService
    {
        Task<IEnumerable<ProductSelectCategoryFormModel>> AllProductProjectCategoryAsync();

        Task<bool> ExsistsByIdAsync(int id);

        Task<IEnumerable<string>> AllProductProjectCategoryNamesAsync();
    }
}
