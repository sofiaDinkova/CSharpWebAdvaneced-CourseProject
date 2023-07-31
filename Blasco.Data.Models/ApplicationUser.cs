namespace Blasco.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Blasco.Common.EntityValidationConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();

            this.Categories = new HashSet<ProductProjectCategory>();
            this.Products = new HashSet<Product>();
            this.Projects = new HashSet<Project>();
        }

        [Required]
        [MaxLength(FirstNameMaxLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLenght)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// UserName_Pseudonym for user in role "Creator".
        /// </summary>
        [MaxLength(PseudonymMaxLenght)]
        public string? UserName_Pseudonym { get; set; }

        /// <summary>
        /// Categories to be associated with for user in role "Creator".
        /// </summary>
        public ICollection<ProductProjectCategory> Categories { get; set; }

        /// <summary>
        /// CustomerType for user in role "Customer".
        /// </summary>
        [ForeignKey(nameof(CustomerType))]
        public int? CustomerTypeId { get; set; }
        public CustomerType? CustomerType { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
