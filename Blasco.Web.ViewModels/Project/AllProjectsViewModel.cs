namespace Blasco.Web.ViewModels.Project
{
    public class AllProjectsViewModel
    {
        public AllProjectsViewModel()
        {
            this.Projects = new HashSet<ProjectViewModel>();
        }
        public int ProjectsCount { get; set; }
        public virtual IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}
