namespace Blasco.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using Data.Models;
    using ViewModels.Creator;
    using ViewModels.Customer;
    using Services.Data.Interfaces;
    using Infrastructure.Extentions;
    using ViewModels.Project;

    using static Common.NotificationMessagesConstents;
    using static Common.GeneralApplicationConstants;

    public class CreatorController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IUserService userService;
        private readonly IVoteService voteService;
        private readonly IChallengeService challengeService;
        private readonly ICreatorService creatorService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> creatorManager;
        private readonly ICustomerTypeService customerTypeService;
        private readonly IMemoryCache memoryCache;


        public CreatorController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> creatorManager, ICustomerTypeService customerTypeService, IProjectService projectService, IUserService userService, IVoteService voteService, IChallengeService challengeService, ICreatorService creatorService, IMemoryCache memoryCache)
        {
            this.signInManager = signInManager;
            this.creatorManager = creatorManager;

            this.customerTypeService = customerTypeService;
            this.projectService = projectService;
            this.userService = userService;
            this.voteService = voteService;
            this.challengeService = challengeService;
            this.creatorService = creatorService;

            this.memoryCache = memoryCache;
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
                Pseudonym = registerStepTwoFormModel.UserName_Pseudonym,
            };

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
            this.memoryCache.Remove(UserCacheKey);

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

        [HttpPost]
        public async Task<IActionResult> Vote(ProjectAllViewModel model)
        {
            bool projectExists = await projectService.ExistsByIdAsync(model.Id);

            if (!projectExists)
            {
                this.TempData[ErrorMessage] = "Project with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "Project");
            }

            bool challengeExists = await this.challengeService.ExistsByIdAsync(model.ChallengeId!);

            if (!challengeExists)
            {
                this.TempData[ErrorMessage] = "Challenge with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "Project");
            }
            try
            {
                bool isCreatorOwner = await this.creatorService.HasProjectWithIdAsync(model.Id, this.User.GetId()!);
                if (isCreatorOwner)
                {
                    this.TempData[ErrorMessage] = "You can not vote for your own Project";
                    return this.RedirectToAction("AllChallenges", "Challenge");
                }

                bool didVoteForChallenge = await this.userService.DidAllreadyVoteForChallengeAsync(this.User.GetId()!, model.ChallengeId!);
                if (didVoteForChallenge)
                {
                    this.TempData[ErrorMessage] = "You can vote only for one Project in a Challenge";
                    return this.RedirectToAction("AllChallenges", "Challenge");
                }

                await this.voteService.CreateVote(this.User.GetId()!, model.Id, model.ChallengeId!);

                this.TempData[WarningMessage] = "You voted successfully for the project";
                return this.RedirectToAction("AllChallenges", "Challenge");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }
        }
    }
}
