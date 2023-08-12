namespace Blasco.Web.ViewModels.Product
{
    using Blasco.Web.ViewModels.Image;
    using Microsoft.AspNetCore.Http;

    public class ProductEditFormModel : ProductFormModel
    {
        public ProductEditFormModel()
        {
            this.ImageDeleteFormModels = new List<ImageDeleteFormModel>();
            this.NewImages = new List<IFormFile>();
        }

        public List<ImageDeleteFormModel> ImageDeleteFormModels { get; set; } = null!;

        public List<IFormFile>? NewImages { get; set; }


    }
}
