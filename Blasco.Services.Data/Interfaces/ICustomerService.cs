namespace Blasco.Services.Data.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> HasProductWithIdAsync(string productId, string userId);
    }
}
