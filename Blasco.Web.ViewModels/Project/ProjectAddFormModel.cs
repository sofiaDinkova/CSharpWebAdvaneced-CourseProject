using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blasco.Web.ViewModels.Project
{
    public class ProjectAddFormModel : ProjectFormModel
    {
        public ProjectAddFormModel()
        {
            this.Images = new List<IFormFile>();
        }

        [Required]
        public List<IFormFile> Images { get; set; } = null!;
    }
}
