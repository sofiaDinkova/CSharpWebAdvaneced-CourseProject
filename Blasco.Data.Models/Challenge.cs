
using System.ComponentModel.DataAnnotations;

using static Blasco.Common.EntityValidationConstants.Challenge;

namespace Blasco.Data.Models
{
    public class Challenge
    {
        public Challenge()
        {
            this.Id = Guid.NewGuid();

            this.Projects = new HashSet<Project>();
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

        public Guid CustomerCreatedChallengeId { get; set; }
        public ApplicationUser CustomerCreatedChallenge { get; set; } = null!;

        public int CategoryId { get; set; }

        public virtual ProductProjectCategory Category { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PriceToWin { get; set; }

        public bool IsOnGoing { get; set; }
        public bool IsActive { get; set; }

        public Guid? WinnerId { get; set; }

        public ApplicationUser? Winner { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
