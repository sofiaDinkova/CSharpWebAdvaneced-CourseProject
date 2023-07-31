using System.ComponentModel.DataAnnotations;

namespace Blasco.Data.Models
{
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
