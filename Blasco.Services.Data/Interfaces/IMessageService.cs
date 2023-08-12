namespace Blasco.Services.Data.Interfaces
{
    using Blasco.Web.ViewModels.Message;
    using MongoDB.Driver.Core.Servers;

    public interface IMessageService
    {
        Task CreateMessageAsync(MessageFormModel formModel, string senderId);
    }
}
