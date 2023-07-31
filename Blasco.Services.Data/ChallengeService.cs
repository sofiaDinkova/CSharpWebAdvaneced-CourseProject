using Blasco.Data;
using Blasco.Data.Models;
using Blasco.Services.Data.Interfaces;
using Blasco.Services.Data.Models.Project;

namespace Blasco.Services.Data
{
    public class ChallengeService : IChallengeService
    {
        private readonly BlascoDbContext dbContext;

        public ChallengeService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<AllProjectsChallengeModel> AllChallengesAsync()
        {
            //IEnumerable<Challenge> allChallanges = this.dbContext
                



            IEnumerable<AllProjectsChallengeModel> allProjectsChallengeModels = new List<AllProjectsChallengeModel>();

            return allProjectsChallengeModels;
        }
    }
}
