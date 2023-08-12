namespace Blasco.Services.Data
{
    using System.Threading.Tasks;

    using Interfaces;
    using Blasco.Data.Models;
    using Web.ViewModels.Message;
    using Blasco.Data;

    public class MessageService : IMessageService
    {
        private readonly BlascoDbContext dbContext;
        public MessageService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateMessageAsync(MessageFormModel formModel, string senderId)
        {
            Message message = new Message()
            {
                Title = formModel.Title,
                Content = formModel.Content,
                ReceiverId = Guid.Parse(formModel.ReceiverId),
                SenderId = Guid.Parse(senderId),
            };

            await this.dbContext.Messages.AddAsync(message);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
