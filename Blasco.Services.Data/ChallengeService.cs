namespace Blasco.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using MongoDB.Driver;

    using Interfaces;
    using Blasco.Data;
    using Blasco.Data.Models;
    using Blasco.Web.ViewModels.Challenge;
    using Blasco.Web.ViewModels.Project;

    public class ChallengeService : IChallengeService
    {
        private readonly BlascoDbContext dbContext;
        private readonly IImageService imageService;

        public ChallengeService(BlascoDbContext dbContext, IImageService imageService)//, IMongoDatabase dbClient)
        {
            this.dbContext = dbContext;
            this.imageService = imageService;
        }
        public async Task<AllChallengesModel> AllChallengesAsync()
        {
            IEnumerable<ChallangeAllViewModel> allChallengeModels = await this.dbContext
                .Challenges
                .Select(c => new ChallangeAllViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    Description = c.Description,
                    Category = c.Category.Name,
                    PriceToWin = c.PriceToWin,
                })
                .ToArrayAsync();
            foreach (var challange in allChallengeModels)
            {
                byte[] biteImg = imageService.GetImageBytesByEntityCorrespondingId(challange.Id);
                challange.ImageArray = biteImg;
            }
            return new AllChallengesModel()
            {
                TotalChallengesCount = allChallengeModels.Count(),
                Challenges = allChallengeModels
            };
        }

        public async Task<string> ChallengeTitleByIdAsync(string challengeId)
        {
            Challenge challenge = await this.dbContext
                .Challenges
                .FirstAsync(c => c.Id.ToString() == challengeId);

            return challenge.Title;
        }

        public async Task<string> ChallengeCategoryNameByIdAsync(string challengeId)
        {
            Challenge challenge = await this.dbContext
                .Challenges
                .Include(c => c.Category)
                .FirstAsync(c => c.Id.ToString() == challengeId);

            return challenge.Category.Name;
        }

        public async Task<int> ReturnCategoryIdByChallengeIdAsync(string challengeId)
        {
            Challenge challenge = await this.dbContext
                .Challenges
                .FirstAsync(c => c.Id.ToString() == challengeId);

            return challenge.CategoryId;
        }

        public async Task AddProductToChallengeAsync(ProjectParticipateViewModel model)
        {
            Project project = await this.dbContext
                .Projects
                .FirstAsync(p => p.Id.ToString() == model.Id);

            Challenge challenge = await this.dbContext
                .Challenges
                .FirstAsync(p => p.Id.ToString() == model.ChallengeId);

            project.ChallengeId = challenge.Id;
            challenge.Projects.Add(project);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string challengeId)
        {
            bool result = await this.dbContext
                .Challenges
                .Where(p => p.IsActive)
                .AnyAsync(p => p.Id.ToString() == challengeId);

            return result;
        }
    }
}
