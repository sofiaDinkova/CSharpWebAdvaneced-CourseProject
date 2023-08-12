namespace Blasco.Services.Data.Interfaces
{
    using Web.ViewModels.Challenge;
    using Web.ViewModels.Project;

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
