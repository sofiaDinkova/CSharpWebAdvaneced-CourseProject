namespace Blasco.Web.ViewModels.Project
{
    using System.ComponentModel.DataAnnotations;

    using Blasco.Web.ViewModels.ProductProjectCategory;
    using static Common.EntityValidationConstants.Project;
    public class ProjectFormModel
    {
        public ProjectFormModel()
        {
            this.ProductProjectCategories = new HashSet<ProductSelectCategoryFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductSelectCategoryFormModel> ProductProjectCategories { get; set; }

    }
}
