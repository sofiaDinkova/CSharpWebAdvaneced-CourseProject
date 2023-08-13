namespace Blasco.Services.Data
{
    using System.Threading.Tasks;

    using Interfaces;
    using Blasco.Data.Models;
    using Web.ViewModels.Message;
    using Blasco.Data;
    using Microsoft.EntityFrameworkCore;
    using Blasco.Web.ViewModels.Home;

    public class MessageService : IMessageService
    {
        private readonly BlascoDbContext dbContext;
        private readonly IUserService userService;
        public MessageService(BlascoDbContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;

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

        public async Task<AllMessagesViewModel> AllMessagesAsync(string userId)
        {
            IEnumerable<MessageAllViewModel> orderedReceived = await this.dbContext
                            .Messages
                            .OrderByDescending(p => p.CreatedOn)
                            .Where(m => m.ReceiverId.ToString() == userId)
                            .Select(m => new MessageAllViewModel
                            {
                                MessageId = m.Id.ToString(),
                                Title = m.Title,
                                SednderName = $"{m.Sender.FirstName} {m.Sender.LastName}",
                                ReceiverName = $"{m.Receiver.FirstName} {m.Receiver.LastName}",
                                CreatedOn = m.CreatedOn,
                                IsRead = m.IsRead,
                            })
                            .ToArrayAsync();

            IEnumerable<MessageAllViewModel> orderedSent = await this.dbContext
                            .Messages
                            .OrderByDescending(p => p.CreatedOn)
                            .Where(m => m.SenderId.ToString() == userId)
                            .Select(m => new MessageAllViewModel
                            {
                                MessageId = m.Id.ToString(),
                                Title = m.Title,
                                SednderName = $"{m.Sender.FirstName} {m.Sender.LastName}",
                                ReceiverName = $"{m.Receiver.FirstName} {m.Receiver.LastName}",
                                CreatedOn = m.CreatedOn,
                                IsRead = m.IsRead,
                            })
                            .ToArrayAsync();

            return new AllMessagesViewModel
            {
                AllRecievedMessages = orderedReceived,
                AllSentMessages = orderedSent
            };

        }
    }
}
