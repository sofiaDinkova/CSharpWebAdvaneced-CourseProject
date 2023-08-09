using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blasco.Web.ViewModels.Product
{
    public class ProductAddFormModel : ProductFormModel
    {
        public ProductAddFormModel()
        {
            this.Images = new List<IFormFile>();
        }

        [Required]
        public List<IFormFile> Images { get; set; } = null!;
    }
}
