namespace Blasco.Web.ViewModels.Message
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Message;

    public class MessageFormModel
    {
        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLenght, MinimumLength = ContentMinLenght)]
        public string Content { get; set; } = null!;

        public string SenderId { get; set; } = null!;

        public string ReceiverId { get; set; } = null!;

        [Display(Name = "Receipient Name")]
        public string ReceiverName { get; set; } = null!;

    }
}
