using Blasco.Data;
using Blasco.Data.Models;
using Blasco.Services.Data.Interfaces;
using Blasco.Services.Data.Models.Product;
using Blasco.Web.ViewModels.Challenge;
using Microsoft.EntityFrameworkCore;


namespace Blasco.Services.Data
{
    public class ChallengeService : IChallengeService
    {
        private readonly BlascoDbContext dbContext;

        public ChallengeService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                    ImageUrl = c.ImageUrl,
                    Category = c.Category.Name,
                    PriceToWin = c.PriceToWin.ToString(),
                })
                .ToArrayAsync();

            return new AllChallengesModel()
            {
                TotalChallengesCount = allChallengeModels.Count(),
                Challenges = allChallengeModels
            };
        }
    }
}
