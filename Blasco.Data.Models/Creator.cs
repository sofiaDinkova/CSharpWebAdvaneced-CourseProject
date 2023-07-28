namespace Blasco.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Blasco.Common.EntityValidationConstants.Creator;

    public class Creator : IdentityUser<Guid>
    {
        public Creator()
        {
            this.Id = Guid.NewGuid();

            this.Products = new HashSet<Product>();
            this.Projects = new HashSet<Project>();
        }

        [Required]
        [MaxLength(FirstNameMaxLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLenght)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(PseudonymMaxLenght)]
        public string Pseudonym { get; set; } = null!;

        public ICollection<Project> Projects { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
