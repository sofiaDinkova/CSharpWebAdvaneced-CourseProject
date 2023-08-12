namespace Blasco.Web.ViewModels.Project
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

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
