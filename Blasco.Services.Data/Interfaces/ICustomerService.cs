using Blasco.Web.ViewModels.Customer;

namespace Blasco.Services.Data.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CustomerExistsByCreatorId(string creatorId);

        Task Create(string creatorId, BecomeCustomerFormModel model);

        Task<string?> GetCustomerByUserIdAsync(string userId);
        
        Task<bool> HasProductWithIdAsync(string productId, string userId);
    }
}
