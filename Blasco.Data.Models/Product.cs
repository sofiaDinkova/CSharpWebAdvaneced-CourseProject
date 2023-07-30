namespace Blasco.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Product;

    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();

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

        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual ProductProjectCategory Category { get; set; } = null!;

        [ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; } = null!;

        [MaxLength(CityNameMaxLenght)]
        public string? City { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid? CustomerId { get; set; }
        public virtual ApplicationUser? Customer { get; set; }

    }
}
