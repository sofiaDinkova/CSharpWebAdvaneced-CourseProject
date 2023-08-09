using System.ComponentModel.DataAnnotations;

namespace Blasco.Web.ViewModels.Product
{
    public class ProductAllViewModel
    {
        public ProductAllViewModel()
        {
            this.ImagesArray = new List<byte[]>();
        }
        public string Id { get; set; } = null!;

        public string Title { get; set; }

        [Display(Name = "Image Link")]

        public string? City { get; set; }

        public decimal Price { get; set; }


        [Display(Name = "Is Purchased")]

        public bool IsPurchased { get; set; }

        public List<byte[]> ImagesArray { get; set; } = null!;

    }
}
