namespace Blasco.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CustomerType
    {
        public CustomerType()
        {
            this.Customers = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<ApplicationUser> Customers { get; set; }
    }
}
