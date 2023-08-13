namespace Blasco.Web.ViewModels.Message
{
    public class AllMessagesViewModel
    {
        public AllMessagesViewModel()
        {
            this.AllRecievedMessages = new HashSet<MessageAllViewModel>();   
            this.AllSentMessages = new HashSet<MessageAllViewModel>();
        }

        public IEnumerable<MessageAllViewModel> AllRecievedMessages { get; set; }
        public IEnumerable<MessageAllViewModel> AllSentMessages { get; set; }
    }
}
