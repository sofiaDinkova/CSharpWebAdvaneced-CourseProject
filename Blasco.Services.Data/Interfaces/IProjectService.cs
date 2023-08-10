namespace Blasco.Services.Data.Interfaces
{
    using Blasco.Services.Data.Models.Project;
    using Blasco.Web.ViewModels.Product;
    using Blasco.Web.ViewModels.Project;
    using Web.ViewModels.Home;

    public interface IProjectService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeProjectAsync();

        Task<AllProjectsFilteredAndPagedModel> AllAsync(AllProjectsQueryModel queryModel);

        Task<AllProjectsViewModel> AllProjectsByChallengeIdAsync(string challengeId);

        Task<IEnumerable<ProjectAllViewModel>> AllProjectsByCreatorIdAndChallengeCategorayIdAsync(string userId, int categoryId);

        Task<string> CreateAndReturnIdAsync(ProjectAddFormModel formModel, string creatorId);
    }
}
