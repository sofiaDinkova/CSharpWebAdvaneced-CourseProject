namespace Blasco.Services.Data.Models.Product
{
    using Web.ViewModels.Product;

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
