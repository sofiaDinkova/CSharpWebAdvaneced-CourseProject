namespace Blasco.Web.ViewModels.Project
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Enum;

    using static Common.GeneralApplicationConstants;

    public class AllProjectsQueryModel
    {
        public AllProjectsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.PrjectsPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Projects = new HashSet<ProjectAllViewModel>();
        }
        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort by")]

        public ProjectSorting ProjectSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Products per page")]
        public int PrjectsPerPage { get; set; }

        public int TotalProjects { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<ProjectAllViewModel> Projects { get; set; } = null!;
    }
}
