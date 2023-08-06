namespace Blasco.Services.Data
{
    using Blasco.Data;
    using Blasco.Data.Models;
    using Blasco.Web.ViewModels.Project;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Home;

    public class ProjectService : IProjectService
    {
        private readonly BlascoDbContext dbContext;
        private readonly IImageService imageService;


        public ProjectService(BlascoDbContext dbContext, IImageService imageService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
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
                    CreatorPseudonym = p.Creator.Pseudonym!,
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

        public async Task<IEnumerable<ProjectAllViewModel>> AllProjectsByCreatorIdAndChallengeCategorayIdAsync(string userId, int categoryId)
        {
            IEnumerable<ProjectAllViewModel> projects = await this.dbContext
                .Projects
                .Where(p=>p.CreatorId.ToString() == userId || p.CategoryId == categoryId)
                .Select(p=> new ProjectAllViewModel
                {
                    Id= p.Id.ToString(),
                    Title= p.Title,
                    Description = p.Description,
                    CreatorPseudonym = p.Creator.Pseudonym!,
                    Votes = p.Votes.Count()
                })
                .ToArrayAsync ();

            return projects;
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
                    ImageArray = imageService.GetImageBytesByEntityCorrespondingId(p.Id.ToString())
                })
                .ToArrayAsync();

            return lastThreeProjects;
        }
    }
}
