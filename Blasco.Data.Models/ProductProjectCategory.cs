namespace Blasco.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.ProductProjectCategory;

    public class ProductProjectCategory
    {
        public ProductProjectCategory()
        {
            this.Projects = new HashSet<Project>();
            this.Products = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}