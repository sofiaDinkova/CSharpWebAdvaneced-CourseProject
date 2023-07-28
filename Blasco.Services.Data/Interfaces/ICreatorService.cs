namespace Blasco.Services.Data.Interfaces
{
    public interface ICreatorService
    {
        Task<bool> CreatorHasProductsAsync(string creatorId);

        Task<bool> HasProductWithIdAsync(string productId, string userId);

        Task<string> GetFullNameByIdAsync(string email);

        Task<string> GetCreatorPseudonymByIdAsync(string email);

    }
}
