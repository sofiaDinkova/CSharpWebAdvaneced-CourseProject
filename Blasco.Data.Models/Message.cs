namespace Blasco.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Message;

    public class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLenght)]
        public string Content { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public bool IsRead { get; set; }

        public bool IsActive { get; set; }

        public Guid SenderId { get; set; }

        public ApplicationUser Sender { get; set; } = null!;

        public Guid ReceiverId { get; set; }

        public ApplicationUser Receiver { get; set; } = null!;

    }
}
