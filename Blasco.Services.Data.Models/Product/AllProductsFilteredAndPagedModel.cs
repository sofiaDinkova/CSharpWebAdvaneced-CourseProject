using Blasco.Web.ViewModels.Product;

namespace Blasco.Services.Data.Models.Product
{
    public class AllProductsFilteredAndPagedModel
    {
        public AllProductsFilteredAndPagedModel()
        {
            this.Products = new HashSet<ProductAllViewModel>();
        }
        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductAllViewModel> Products { get; set; }
    }
}
