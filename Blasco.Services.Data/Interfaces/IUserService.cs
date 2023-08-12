namespace Blasco.Services.Data.Interfaces
{
    using Web.ViewModels.Creator;

    public interface IUserService
    {
        Task<string> GetFullNameByIdAsync(string id);

        Task<IEnumerable<UserViewModel>> AllUsersAsync();

        Task<bool> DidAllreadyVoteForChallengeAsync(string userId, string challengeId);

        Task<bool> ExistByIdAsync(string userId);
    }
}
