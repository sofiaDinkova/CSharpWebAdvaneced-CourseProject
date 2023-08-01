namespace Blasco.Services.Data.Interfaces
{
    using Blasco.Web.ViewModels.Project;
    using Web.ViewModels.Home;

    public interface IProjectService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeProjectAsync();

        Task<AllProjectsViewModel> AllProjectsByChallengeIdAsync(string challengeId);
    }
}
