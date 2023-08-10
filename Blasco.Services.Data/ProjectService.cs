namespace Blasco.Services.Data
{
    using Blasco.Data;
    using Blasco.Data.Models;
    using Blasco.Services.Data.Models.Product;
    using Blasco.Web.ViewModels.Product.Enums;
    using Blasco.Web.ViewModels.Product;
    using Blasco.Web.ViewModels.Project;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Home;
    using Blasco.Services.Data.Models.Project;
    using Blasco.Web.ViewModels.Project.Enum;

    public class ProjectService : IProjectService
    {
        private readonly BlascoDbContext dbContext;
        private readonly IImageService imageService;
        private readonly ICreatorService creatorService;


        public ProjectService(BlascoDbContext dbContext, IImageService imageService, ICreatorService creatorService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
            this.creatorService = creatorService;
        }

        public async Task<AllProjectsFilteredAndPagedModel> AllAsync(AllProjectsQueryModel queryModel)
        {
            IQueryable<Project> projectQuery = this.dbContext
                .Projects
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                projectQuery = projectQuery
                    .Where(p => p.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                projectQuery = projectQuery
                    .Where(p => EF.Functions.Like(p.Title, wildCard) ||
                              EF.Functions.Like(p.Description, wildCard));
            }

            projectQuery = queryModel.ProjectSorting switch
            {   
                ProjectSorting.Newest => projectQuery
                     .OrderByDescending(p => p.CreatedOn),
                ProjectSorting.Oldest => projectQuery
                    .OrderBy(p => p.CreatedOn),                
                _ => projectQuery
                    .OrderBy(p => p.CreatedOn)
            };


            IEnumerable<ProjectAllViewModel> allProjects = await projectQuery
                .Where(p => p.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.PrjectsPerPage)
                .Take(queryModel.PrjectsPerPage)
                .Select(p => new ProjectAllViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Description = p.Description,
                    CreatorPseudonym = p.Creator.Pseudonym!
                })
                .ToArrayAsync();

            int totalProducts = projectQuery.Count();

            foreach (var product in allProjects)
            {
                List<byte[]> biteImg = imageService.GetAllImagesBytesByEntityCorrespondingId(product.Id);
                product.ImagesArray = biteImg;
            }

            return new AllProjectsFilteredAndPagedModel()
            {
                TotalProjectsCount = totalProducts,
                Projects = allProjects
            };
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
