namespace Blasco.Services.Data.Interfaces
{
    public interface ICreatorService
    {
        Task<bool> CreatorHasProductsAsync(string creatorId);
    }
}
