using Blasco.Services.Data.Models.Product;
using Blasco.Services.Data.Models.Statistics;
using Blasco.Web.ViewModels.Home;
using Blasco.Web.ViewModels.Product;

namespace Blasco.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeProductAsync();

        Task<string> CreateAndReturnIdAsync(ProductAddFormModel formModel, string creatorId);

        Task<AllProductsFilteredAndPagedModel> AllAsync(AllProductsQueryModel queryModel);

        Task<IEnumerable<ProductAllViewModel>> AllByCustomerIdAsync(string customerId);

        Task<IEnumerable<ProductAllViewModel>> AllByCreatorIdAsync(string creatorId);

        Task<ProductDetailsViewModel> GetDetailsByIdAsync(string productId);

        Task<bool> ExistsByIdAsync(string productId);

        Task<ProductEditFormModel> GetProductForEditByIdAsync(string productId);

        Task<bool> IsCreatorWithIdOwnerOfProductWithIdAsync(string productId, string creatorId);

        Task EditProductByIdAndFormModelAsync(string productId, ProductEditFormModel formModel);

        Task DeleteProductByIdAsync(string id);

        Task<bool> IsPurchasedByIdAsync(string productId);

        Task PuchaseProductAsync(string productId, string userId);

        Task<bool> isPurchesedByCustomerWithIdAsync(string productId, string customerId);

        Task CancelProductAsync(string productId, string customerId);

        Task<StatisticsServiceModel> GetStatisticsAsync();

    }
}
