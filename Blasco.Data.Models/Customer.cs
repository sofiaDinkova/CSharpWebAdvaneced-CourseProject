namespace Blasco.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;
    using static Common.EntityValidationConstants.Customer;

    public class Customer
    {

        public Customer()
        {
            this.Id = Guid.NewGuid();
            this.Products = new HashSet<Product>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(0, MaxNumEnumCustomerType)]
        public CustomerType CustomerType { get; set; }

        [ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }

        public virtual Creator Creator { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
