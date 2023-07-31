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
            this.Votes = new HashSet<Vote>();  
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

        public int CategoryId { get; set; }

        public virtual ProductProjectCategory Category { get; set; } = null!;

        public Guid CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; } = null!;

        public virtual ICollection<Vote> Votes { get; set; }

        public Guid? ChallengeId { get; set; }

        public Challenge? Challenge { get; set; }
    }
}
