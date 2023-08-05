using Blasco.Data.Models;
using Blasco.Web.ViewModels.Challenge;
using Blasco.Web.ViewModels.Product;

namespace Blasco.Services.Data.Interfaces
{
    public interface IChallengeService
    {
        public Task<AllChallengesModel> AllChallengesAsync();

        Task<int> ReturnCategoryIdByChallengeIdAsync(string challengeId);
    }
}
