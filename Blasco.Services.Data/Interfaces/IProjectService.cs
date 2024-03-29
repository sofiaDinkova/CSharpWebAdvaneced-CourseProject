﻿namespace Blasco.Services.Data.Interfaces
{
    using Models.Project;
    using Web.ViewModels.Project;
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

        Task<IEnumerable<ProjectAllViewModel>> GetAllByCreatorIdAsync(string creatorId);

        Task DeleteProductByIdAsync(string id);

        Task WithdrawProjectWithIdFromChalengeAsync(string projectId);
    }
}
