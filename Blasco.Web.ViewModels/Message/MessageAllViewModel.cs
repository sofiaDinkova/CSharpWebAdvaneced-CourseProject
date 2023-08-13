namespace Blasco.Web.ViewModels.Message
{
    public class MessageAllViewModel
    {
        public string MessageId { get; set; } = null!;

        public string SednderName { get; set; } = null!;

        public string ReceiverName { get; set; } = null!;

        public string Title { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public bool IsRead { get; set; }
    }
}
