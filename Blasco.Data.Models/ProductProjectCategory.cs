namespace Blasco.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.ProductProjectCategory;

    public class ProductProjectCategory
    {
        public ProductProjectCategory()
        {
            this.Creators = new HashSet<ApplicationUser>();
            this.Projects = new HashSet<Project>();
            this.Products = new HashSet<Product>();
            this.Challenges = new HashSet<Challenge>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        public virtual ICollection<ApplicationUser> Creators { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Challenge> Challenges { get; set; }

    }
}