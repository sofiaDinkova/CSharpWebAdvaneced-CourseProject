namespace Blasco.Web.ViewModels.Product
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Blasco.Web.ViewModels.ProductProjectCategory;
    using static Common.EntityValidationConstants.Product;
    using Microsoft.AspNetCore.Http;

    public class ProductFormModel
    {
        public ProductFormModel()
        {
            this.ProductProjectCategories = new HashSet<ProductSelectCategoryFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; } = null!;
                
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductSelectCategoryFormModel> ProductProjectCategories { get; set; }

        [StringLength(CityNameMaxLenght, MinimumLength =CityNameMinLenght)]
        public string? City { get; set; }
    }
}
