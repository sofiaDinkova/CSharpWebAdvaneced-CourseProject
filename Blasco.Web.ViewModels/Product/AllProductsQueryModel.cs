namespace Blasco.Web.ViewModels.Product
{
    using Blasco.Web.ViewModels.Product.Enums;
    using static Common.GeneralApplicationConstants;

using System.ComponentModel.DataAnnotations;
    public class AllProductsQueryModel
    {
        public AllProductsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.ProductsPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Products = new HashSet<ProductAllViewModel>();
        }
        public string? Category { get; set; }

        [Display(Name ="Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort by")]

        public ProductSorting ProductSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Products per page")]
        public int ProductsPerPage { get; set; }

        public int TotalProducts { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<ProductAllViewModel> Products { get; set; } = null!;
    }
}
