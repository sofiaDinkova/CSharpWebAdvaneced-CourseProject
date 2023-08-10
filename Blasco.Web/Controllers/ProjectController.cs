namespace Blasco.Web.Controllers
{
    using Blasco.Services.Data.Interfaces;
    using Blasco.Services.Data.Models.Product;
    using Blasco.Services.Data.Models.Project;
    using Blasco.Web.Infrastructure.Extentions;
    using Blasco.Web.ViewModels.Product;
    using Blasco.Web.ViewModels.Project;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationMessagesConstents;


    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProductProjectCategoryService productProjectCategoryService;
        private readonly IProjectService projectService;
        private readonly IChallengeService challengeService;


        public ProjectController(IProjectService projectService, IChallengeService challengeService, IProductProjectCategoryService productProjectCategoryService)
        {
            this.projectService = projectService;
            this.challengeService = challengeService;
            this.productProjectCategoryService = productProjectCategoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllProjects([FromQuery] AllProjectsQueryModel queryModel)
        {
            try
            {
                AllProjectsFilteredAndPagedModel serviceModel = await this.projectService.AllAsync(queryModel);

                queryModel.Projects = serviceModel.Projects;
                queryModel.TotalProjects = serviceModel.TotalProjectsCount;
                queryModel.Categories = await this.productProjectCategoryService.AllProductProjectCategoryNamesAsync();

                return this.View(queryModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured! Please try again letar or contact an administrator.";

                return this.RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllProjectsInChallenge(string id)
        {
            //check if EXISTSSS!!!!
            try
            {
                AllProjectsViewModel model = await this.projectService.AllProjectsByChallengeIdAsync(id);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Participate(string challengeId)
        {
            if (!this.User.IsCreator()) 
            {
                this.TempData[ErrorMessage] = "You must be Creator to participate in challenges";
                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                string userId = this.User.GetId()!;
                int categoryId = await this.challengeService.ReturnCategoryIdByChallengeIdAsync(challengeId);

                IEnumerable<ProjectAllViewModel> projectsAllowed = await this.projectService.AllProjectsByCreatorIdAndChallengeCategorayIdAsync(userId, categoryId);

                return this.View(projectsAllowed);
            }
            catch (Exception)
            {
                //TODO GeneralError
                this.TempData[ErrorMessage] = "Unexpected error occured! Please try again letar or contact an administrator.";

                return this.RedirectToAction("Index", "Home");
            }
        }


        
    }
}
