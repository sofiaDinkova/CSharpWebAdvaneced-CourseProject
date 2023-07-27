using Blasco.Data.Models;
using Blasco.Web.ViewModels.Creator;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blasco.Web.Controllers
{
    public class CreatorController : Controller
    {
        private readonly SignInManager<Creator> signInManager;
        private readonly UserManager<Creator> creatorManager;
        private readonly IUserStore<Creator> creatorStore;

        public CreatorController(SignInManager<Creator> signInManager, UserManager<Creator> creatorManager)
        {
            this.signInManager = signInManager;
            this.creatorManager = creatorManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            Creator creator = new Creator()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await this.creatorManager.SetUserNameAsync(creator, model.Email);
            await this.creatorManager.SetEmailAsync(creator, model.Email);

            IdentityResult result = await this.creatorManager.CreateAsync(creator, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError errorr in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, errorr.Description);
                }

                return View(model);
            }

            await this.signInManager.SignInAsync(creator, false);

            return this.RedirectToAction("Index", "Home");

        }
    }
}
