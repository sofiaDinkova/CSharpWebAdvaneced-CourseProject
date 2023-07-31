using Blasco.Data.Models;
using Blasco.Web.ViewModels.Creator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Blasco.Common.NotificationMessagesConstents;
using static Blasco.Common.GeneralApplicationConstants;
using Blasco.Web.ViewModels.Customer;
using Blasco.Services.Data.Interfaces;

namespace Blasco.Web.Controllers
{
    public class CreatorController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> creatorManager;
        private readonly ICustomerTypeService customerTypeService;


        public CreatorController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> creatorManager, ICustomerTypeService customerTypeService)
        {
            this.signInManager = signInManager;
            this.creatorManager = creatorManager;

            this.customerTypeService = customerTypeService;
        }

        [HttpGet]
        public IActionResult RegisterStepOne()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult RegisterStepOne(RegisterStepOneFormModel registerStepOneFormModel)
        {
            if (registerStepOneFormModel.Role == CreatorRoleName)
            {
                Register register = new Register()
                {
                    registerStepOneFormModel = registerStepOneFormModel
                };

                return this.RedirectToAction("RegisterCreatorStepTwo", "Creator", registerStepOneFormModel);
            }
            if (registerStepOneFormModel.Role == CustomerRoleName)
            {
                Register register = new Register()
                {
                    registerStepOneFormModel = registerStepOneFormModel
                };

                return this.RedirectToAction("RegisterCustomerStepTwo", "Creator", registerStepOneFormModel);
            }
            return this.RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult RegisterCreatorStepTwo(RegisterStepOneFormModel registerStepOneFormModel)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCreatorStepTwo(RegisterStepOneFormModel registerStepOneFormModel, RegisterCreatorStepTwoFormModel registerStepTwoFormModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(registerStepTwoFormModel);
            }

            ApplicationUser creator = new ApplicationUser()
            {
                FirstName = registerStepTwoFormModel.FirstName,
                LastName = registerStepTwoFormModel.LastName,
                UserName_Pseudonym = registerStepTwoFormModel.UserName_Pseudonym,
            };

            //await this.creatorManager.AddClaimAsync(creator, new Claim("SomeClaim", model.SomeClaim));

            await this.creatorManager.SetUserNameAsync(creator, registerStepTwoFormModel.Email);
            await this.creatorManager.SetEmailAsync(creator, registerStepTwoFormModel.Email);

            IdentityResult result = await this.creatorManager.CreateAsync(creator, registerStepTwoFormModel.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError errorr in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, errorr.Description);
                }

                return this.View(registerStepTwoFormModel);
            }

            if (registerStepOneFormModel.Role == CreatorRoleName)
            {
                await creatorManager.AddToRoleAsync(creator, CreatorRoleName);
            }

            await this.signInManager.SignInAsync(creator, false);

            return this.RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public async Task<IActionResult> RegisterCustomerStepTwo(RegisterStepOneFormModel registerStepOneFormModel)
        {
            try
            {
                RegisterCustomerStepTwoFormModel formModel = new RegisterCustomerStepTwoFormModel();
                formModel.CustomerTypes = await this.customerTypeService.AllCustomerTypesAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("Index", "Home");
            }
            //return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomerStepTwo(RegisterStepOneFormModel registerStepOneFormModel, RegisterCustomerStepTwoFormModel registerStepTwoFormModel)
        {

            if (!ModelState.IsValid)
            {
                return this.View(registerStepTwoFormModel);
            }

            ApplicationUser customer = new ApplicationUser()
            {
                FirstName = registerStepTwoFormModel.FirstName,
                LastName = registerStepTwoFormModel.LastName,
                CustomerTypeId = registerStepTwoFormModel.CustomerTypeId,
            };

            //await this.creatorManager.AddClaimAsync(creator, new Claim("SomeClaim", model.SomeClaim));

            await this.creatorManager.SetUserNameAsync(customer, registerStepTwoFormModel.Email);
            await this.creatorManager.SetEmailAsync(customer, registerStepTwoFormModel.Email);

            IdentityResult result = await this.creatorManager.CreateAsync(customer, registerStepTwoFormModel.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError errorr in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, errorr.Description);
                }

                return this.View(registerStepTwoFormModel);
            }

            if (registerStepOneFormModel.Role == CustomerRoleName)
            {
                await creatorManager.AddToRoleAsync(customer, CreatorRoleName);
            }

            await this.signInManager.SignInAsync(customer, false);

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
