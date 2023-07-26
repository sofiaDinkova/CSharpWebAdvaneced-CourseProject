using System.ComponentModel.DataAnnotations;

namespace Blasco.Web.ViewModels.Product
{
    public class ProductAllViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Image Link")]
        public string ImageUrl  { get; set; }
        public string? City { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Is Purchased")]
        public bool IsPurchased { get; set; }
    }
}
