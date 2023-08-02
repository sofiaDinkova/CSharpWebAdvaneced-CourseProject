namespace Blasco.Services.Data
{
    using Blasco.Data;
    using Blasco.Web.ViewModels.Project;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Home;

    public class ProjectService : IProjectService
    {
        private readonly BlascoDbContext dbContext;

        public ProjectService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllProjectsViewModel> AllProjectsByChallengeIdAsync(string challengeId)
        {
            IEnumerable<ProjectAllViewModel> projectViewModels = await this.dbContext
                .Projects
                .Where(p => p.ChallengeId.ToString() == challengeId)
                .Select(p => new ProjectAllViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Description= p.Description,
                    CreatorPseudonym = p.Creator.UserName_Pseudonym!,
                    ImageUrl = p.ImageUrl,
                    Votes = p.Votes.Count()
                })
                .ToArrayAsync();
            int projectCount = projectViewModels.Count();

            return new AllProjectsViewModel
            {
                Projects = projectViewModels,
                ProjectsCount = projectCount
            };
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeProjectAsync()
        {
            IEnumerable<IndexViewModel> lastThreeProjects = await this.dbContext
                .Projects
                .OrderByDescending(p => p.CreatedOn)
                .Take(3)
                .Select(p => new IndexViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                })
                .ToArrayAsync();

            return lastThreeProjects;
        }
    }
}
