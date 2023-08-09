using Blasco.Web.ViewModels.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Web.ViewModels.Product
{
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
