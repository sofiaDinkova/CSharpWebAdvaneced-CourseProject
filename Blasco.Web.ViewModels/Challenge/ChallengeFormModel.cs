namespace Blasco.Web.ViewModels.Challenge
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using ProductProjectCategory;

    using static Common.EntityValidationConstants.Challenge;

    public class ChallengeFormModel
    {
        public ChallengeFormModel()
        {
            this.ProductProjectCategories = new HashSet<ProductSelectCategoryFormModel>();
        }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;

        public Guid CustomerCreatedChallengeId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductSelectCategoryFormModel> ProductProjectCategories { get; set; }

        [Display(Name = "Giveaway Price")]
        public decimal PriceToWin { get; set; }
       
        [Required]
        public IFormFile Image { get; set; }
    }
}
