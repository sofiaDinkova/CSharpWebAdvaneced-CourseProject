﻿using Blasco.Data.Models;
using Blasco.Web.ViewModels.Creator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Blasco.Common.NotificationMessagesConstents;

namespace Blasco.Web.Controllers
{
    public class CreatorController : Controller
    {
        private readonly SignInManager<Creator> signInManager;
        private readonly UserManager<Creator> creatorManager;
        
        public CreatorController(SignInManager<Creator> signInManager, UserManager<Creator> creatorManager)
        {
            this.signInManager = signInManager;
            this.creatorManager = creatorManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
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

                return this.View(model);
            }

            await this.signInManager.SignInAsync(creator, false);

            return this.RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };


            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

           var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                this.TempData[ErrorMessage] = "There was an error while logging you in. Prease try again letar or contact administrator";

                return this.View(model);
            }

            return this.Redirect(model.ReturnUrl ?? "/Home/Index");
        }
    }
}
