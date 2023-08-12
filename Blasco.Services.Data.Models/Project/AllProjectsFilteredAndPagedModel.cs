namespace Blasco.Services.Data.Models.Project
{
    using Web.ViewModels.Project;

    public class AllProjectsFilteredAndPagedModel
    {
        public AllProjectsFilteredAndPagedModel()
        {
            this.Projects = new HashSet<ProjectAllViewModel>();
        }
        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectAllViewModel> Projects { get; set; }
    }
}
