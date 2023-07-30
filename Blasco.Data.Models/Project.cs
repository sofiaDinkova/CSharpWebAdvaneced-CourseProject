namespace Blasco.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Project;

    public class Project
    {
        public Project()
        {
            this.Id = Guid.NewGuid();

        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual ProductProjectCategory Category { get; set; } = null!;

        [ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; } = null!;
    }
}
