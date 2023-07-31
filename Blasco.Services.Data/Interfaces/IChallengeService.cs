using Blasco.Data.Models;
using Blasco.Services.Data.Models.Project;

namespace Blasco.Services.Data.Interfaces
{
    public interface IChallengeService
    {
        public IEnumerable<AllProjectsChallengeModel> AllChallengesAsync();
    }
}
