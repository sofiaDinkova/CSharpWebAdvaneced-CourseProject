using Blasco.Data.Models;
using Blasco.Web.ViewModels.Challenge;
using Blasco.Web.ViewModels.Product;
using Blasco.Web.ViewModels.Project;

namespace Blasco.Services.Data.Interfaces
{
    public interface IChallengeService
    {
        Task<AllChallengesModel> AllChallengesAsync();

        Task<int> ReturnCategoryIdByChallengeIdAsync(string challengeId);

        Task<string> ChallengeTitleByIdAsync(string challengeId);

        Task<string> ChallengeCategoryNameByIdAsync(string challengeId);

        Task AddProductToChallengeAsync(ProjectParticipateViewModel model);

        Task<bool> ExistsByIdAsync(string challengeId);
    }
}
