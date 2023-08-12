namespace Blasco.Web.ViewModels.Project
{
    using Microsoft.AspNetCore.Http;

    using Image;

    public class ProjectEditFormModel : ProjectFormModel
    {
        public ProjectEditFormModel()
        {
            this.ImageDeleteFormModels = new List<ImageDeleteFormModel>();
            this.NewImages = new List<IFormFile>();
        }

        public List<ImageDeleteFormModel> ImageDeleteFormModels { get; set; } = null!;

        public List<IFormFile>? NewImages { get; set; }

    }
}
