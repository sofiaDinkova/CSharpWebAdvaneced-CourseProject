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

        Task<IEnumerable<ProjectParticipateViewModel>> AllProjectsByCreatorIdAndChallengeCategorayIdAsync(string userId, int categoryId, string challengeId);

        Task<string> CreateAndReturnIdAsync(ProjectAddFormModel formModel, string creatorId);

        Task<bool> ExistsByIdAsync(string productId);

        Task<ProjectEditFormModel> GetProjectForEditByIdAsync(string projectId);

        Task EditProjectByIdAndFormModelAsync(string productId, ProjectEditFormModel formModel);

        Task<ProjectDetailsViewModel> GetDetailsByIdAsync(string productId);
    }
}
