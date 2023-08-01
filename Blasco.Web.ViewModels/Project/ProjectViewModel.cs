namespace Blasco.Web.ViewModels.Project
{
    public class ProjectViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string CreatorPseudonym { get; set; } = null!;

        public int Votes { get; set; }
    }
}
