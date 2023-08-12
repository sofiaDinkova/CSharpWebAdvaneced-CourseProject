namespace Blasco.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using ViewModels.Challenge;

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
