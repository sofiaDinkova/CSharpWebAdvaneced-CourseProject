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
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using System.Collections.Generic;

    public class ProjectService : IProjectService
    {
        private readonly BlascoDbContext dbContext;
        private readonly IImageService imageService;
        private readonly ICreatorService creatorService;
        private readonly IChallengeService challengeService;


        public ProjectService(BlascoDbContext dbContext, IImageService imageService, ICreatorService creatorService, IChallengeService challengeService)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
            this.creatorService = creatorService;
            this.challengeService = challengeService;
        }

        public async Task<bool> ExistsByIdAsync(string productId)
        {
            bool result = await this.dbContext
                .Projects
                .Where(p => p.IsActive)
                .AnyAsync(p => p.Id.ToString() == productId);

            return result;
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
                    Description = p.Description,
                    CreatorPseudonym = p.Creator.Pseudonym!,
                    Votes = p.Votes.Count(),
                    ImagesArray = imageService.GetAllImagesBytesByEntityCorrespondingId(p.Id.ToString()),
                    ChallengeId = challengeId
                })
                .ToArrayAsync();
            int projectCount = projectViewModels.Count();

            return new AllProjectsViewModel
            {
                Projects = projectViewModels,
                ProjectsCount = projectCount
            };
        }

        public async Task<IEnumerable<ProjectParticipateViewModel>> AllProjectsByCreatorIdAndChallengeCategorayIdAsync(string userId, int categoryId, string challengeId)
        {
            string challengeTitle = await this.challengeService.ChallengeTitleByIdAsync(challengeId);
            string challengeCategoryName = await this.challengeService.ChallengeCategoryNameByIdAsync(challengeId);

            IEnumerable<ProjectParticipateViewModel> projects = await this.dbContext
                .Projects
                .Where(p => p.IsActive == true &&
                            p.CreatorId.ToString() == userId &&
                            p.CategoryId == categoryId && p.ChallengeId.ToString() != challengeId)
                .Select(p => new ProjectParticipateViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Description = p.Description,
                    CreatorPseudonym = p.Creator.Pseudonym!,
                    Votes = p.Votes.Count(),
                    ImagesArray = imageService.GetAllImagesBytesByEntityCorrespondingId(p.Id.ToString()),
                    ChallengeId = challengeId,
                    ChallengeName = challengeTitle,
                    ChallengeCategory = challengeCategoryName
                })
                .ToArrayAsync();

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

        public async Task<string> CreateAndReturnIdAsync(ProjectAddFormModel formModel, string creatorId)
        {
            Project product = new Project
            {
                Title = formModel.Title,
                Description = formModel.Description,
                CategoryId = formModel.CategoryId,
                CreatorId = Guid.Parse(creatorId),
            };

            await this.dbContext.Projects.AddAsync(product);
            await this.dbContext.SaveChangesAsync();

            await this.imageService.InsertImagesAsync(formModel.Images, product.Id.ToString());

            return product.Id.ToString();
        }

        public async Task<ProjectEditFormModel> GetProjectForEditByIdAsync(string projectId)
        {
            Project project = await this.dbContext
                .Projects
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .FirstAsync(h => h.Id.ToString() == projectId);

            return new ProjectEditFormModel
            {
                Title = project.Title,
                Description = project.Description,
                CategoryId = project.CategoryId,
                ImageDeleteFormModels = this.imageService.GetImagesToEditByEntityCorrespondingIdAsync(projectId)
            };
        }

        public async Task EditProjectByIdAndFormModelAsync(string productId, ProjectEditFormModel formModel)
        {
            Project project = await this.dbContext
                .Projects
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == productId);

            project.Title = formModel.Title;
            project.Description = formModel.Description;
            project.CategoryId = formModel.CategoryId;

            for (int i = 0; i < formModel.ImageDeleteFormModels.Count(); i++)
            {
                if (formModel.ImageDeleteFormModels.ElementAt(i).ToBeDeleted == true)
                {
                    await this.imageService.DeleteProductImageByImageId(formModel.ImageDeleteFormModels.ElementAt(i).Id);
                }
            }

            if (formModel.NewImages.Any())
            {
                await this.imageService.InsertImagesAsync(formModel.NewImages, productId);
            }


            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ProjectDetailsViewModel> GetDetailsByIdAsync(string productId)
        {
            Project project = await this.dbContext
                .Projects
                .Include(p => p.Category)
                .Include(p => p.Creator)
                .Where(p => p.IsActive)
                .FirstAsync(h => h.Id.ToString() == productId);

            string creatorEmail = project.Creator.Email;
            string creatorPseudonym = project.Creator.Pseudonym;

            return new ProjectDetailsViewModel
            {
                Id = project.Id.ToString(),
                Title = project.Title,
                Description = project.Description,
                Category = project.Category.Name,
                CreatorId = project.CreatorId.ToString(),
                CreatorEmail = creatorEmail,
                CreatorPseudonym = creatorPseudonym,
                ImagesArray = imageService.GetAllImagesBytesByEntityCorrespondingId(project.Id.ToString())
            };
        }

        public async Task<IEnumerable<ProjectAllViewModel>> GetAllByCreatorIdAsync(string creatorId)
        {
            IEnumerable<ProjectAllViewModel> allProjects = await this.dbContext
                .Projects
                .Include(p=>p.Creator)
                .Where(p=>p.CreatorId.ToString() == creatorId)
                .Select(p => new ProjectAllViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Description = p.Description,
                    CreatorPseudonym = p.Creator.Pseudonym!,
                    ImagesArray = imageService.GetAllImagesBytesByEntityCorrespondingId(p.Id.ToString())
                })
                .ToArrayAsync();

            return allProjects;
        }

        public async Task DeleteProductByIdAsync(string id)
        {
            Project projectToDelete = await this.dbContext
            .Projects
            .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == id);

            projectToDelete.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task WithdrawProjectWithIdFromChalengeAsync(string projectId)
        {
            Project project = await this.dbContext
                .Projects
                .FirstAsync(p => p.Id.ToString() == projectId);

            project.ChallengeId = null;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
