using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Blasco.Web.ViewModels.Product
{
    public class ProductPreDeleteDetailsViewModel
    {
        public string Title { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
