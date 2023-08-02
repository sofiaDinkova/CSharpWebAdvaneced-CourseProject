namespace Blasco.Web.ViewModels.Project
{
    public class AllProjectsViewModel
    {
        public AllProjectsViewModel()
        {
            this.Projects = new HashSet<ProjectAllViewModel>();
        }
        public int ProjectsCount { get; set; }
        public virtual IEnumerable<ProjectAllViewModel> Projects { get; set; }
    }
}
