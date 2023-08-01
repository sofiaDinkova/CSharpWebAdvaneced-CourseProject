using Blasco.Data.Models;
using Blasco.Web.ViewModels.Challenge;

namespace Blasco.Services.Data.Interfaces
{
    public interface IChallengeService
    {
        public Task<AllChallengesModel> AllChallengesAsync();
    }
}
