
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
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public bool IsOnGoing { get; set; }

        public Guid? WinnerId { get; set; }

        public ApplicationUser? Winner { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
