namespace Blasco.Services.Data
{
    using Blasco.Data;
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
