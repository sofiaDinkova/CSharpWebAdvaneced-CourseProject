namespace Blasco.Services.Data.Interfaces
{
    public interface ICreatorService
    {
        Task<bool> HasProductWithIdAsync(string productId, string userId);

        Task<bool> HasProjectWithIdAsync(string productId, string userId);

        Task<string> GetFullNameByEmailAsync(string email);

        Task<string> GetCreatorPseudonymByEmailAsync(string email);

        Task<string> GetCreatorPseudonymByIdAsync(string userId);
    }
}
