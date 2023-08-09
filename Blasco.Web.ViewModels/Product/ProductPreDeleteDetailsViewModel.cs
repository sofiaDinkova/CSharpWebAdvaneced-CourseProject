using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Blasco.Web.ViewModels.Product
{
    public class ProductPreDeleteDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public byte[] ImageArray { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
