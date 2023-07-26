using Blasco.Services.Data.Models.Product;
using Blasco.Web.ViewModels.Home;
using Blasco.Web.ViewModels.Product;

namespace Blasco.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeProductAsync();

        Task<string> CreateAndReturnIdAsync(ProductFormModel formModel, string creatorId);

        Task<AllProductsFilteredAndPagedModel> AllAsync(AllProductsQueryModel queryModel);

        Task<IEnumerable<ProductAllViewModel>> AllByCustomerIdAsync(string customerId);

        Task<IEnumerable<ProductAllViewModel>> AllByCreatorIdAsync(string creatorId);

        Task<ProductDetailsViewModel> GetDetailsByIdAsync(string productId);

        Task<bool> ExistsByIdAsync(string productId);

        Task<ProductFormModel> GetProductForEditByIdAsync(string productId);

        Task<bool> IsCreatorWithIdOwnerOfProductWithIdAsync(string productId, string creatorId);

        Task EditProductByIdAndFormModelAsync(string productId, ProductFormModel formModel);

        Task<ProductPreDeleteDetailsViewModel> GetProductForDeleteByIdAsync(string productid);

        Task DeleteProductByIdAsync(string id);

    }
}
