namespace Blasco.Web.ViewModels.Project
{
    public class ProjectAllViewModel
    {
        public ProjectAllViewModel()
        {
            this.ImagesArray = new List<byte[]>();
        }

        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CreatorPseudonym { get; set; } = null!;

        public int? Votes { get; set; }

        public List<byte[]> ImagesArray { get; set; } = null!;

        public string? ChallengeId { get; set; }
    }
}
