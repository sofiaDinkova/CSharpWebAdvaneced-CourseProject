using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Web.ViewModels.Image
{
    public class ImageDeleteFormModel
    {
        public string? Id { get; set; }
        public byte[]? ExistingImage { get; set; } 
        public bool ToBeDeleted { get; set; }
    }
}
