using Blasco.Services.Data.Interfaces;
using Blasco.Services.Data.Models.Product;
using Blasco.Web.ViewModels.Product;
using Blasco.Web.ViewModels.Challenge;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blasco.Web.Controllers
{
    [Authorize]
    public class ChallengeController : Controller
    {
        private readonly IChallengeService challengeService;

        public ChallengeController(IChallengeService challengeService)
        {
            this.challengeService = challengeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllChallenges()
        {
            try
            {
                AllChallengesModel viewModel = await this.challengeService.AllChallengesAsync();

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("Index", "Home");
            }
        }

    }
}
