using Blasco.Data.Models;

namespace Blasco.Web.ViewModels.Project
{
    public class ProjectChallegeViewModel
    {
        public ProjectChallegeViewModel()
        {
           this.Votes = new HashSet<Vote>();
        }

        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string CategoryId { get; set; } = null!;

        public virtual ApplicationUser Creator { get; set; } = null!;

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
