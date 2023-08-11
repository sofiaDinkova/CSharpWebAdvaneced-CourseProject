using Blasco.Web.ViewModels.Creator;

namespace Blasco.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameByIdAsync(string id);

        Task<IEnumerable<UserViewModel>> AllUsersAsync();

        Task<bool> DidAllreadyVoteForChallengeAsync(string userId, string challengeId);
    }
}
