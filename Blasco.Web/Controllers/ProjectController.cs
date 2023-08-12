namespace Blasco.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis;

    using Services.Data.Interfaces;
    using Services.Data.Models.Project;
    using Infrastructure.Extentions;
    using ViewModels.Project;

    using static Common.NotificationMessagesConstents;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProductProjectCategoryService productProjectCategoryService;
        private readonly IProjectService projectService;
        private readonly IChallengeService challengeService;
        private readonly ICreatorService creatorService;
        private readonly IImageService imageService;
        private readonly IUserService userService;


        public ProjectController(IProjectService projectService, IChallengeService challengeService, IProductProjectCategoryService productProjectCategoryService, ICreatorService creatorService, IImageService imageService, IUserService userService)
        {
            this.projectService = projectService;
            this.challengeService = challengeService;
            this.productProjectCategoryService = productProjectCategoryService;
            this.creatorService = creatorService;
            this.imageService = imageService;
            this.userService = userService;
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
        public async Task<IActionResult> Add()
        {
            try
            {
                if (this.User.IsCustomer())
                {
                    this.TempData[ErrorMessage] = "You must be a creator to add new Products";
                    return this.RedirectToAction("Home", "Index");
                }

                ProjectAddFormModel formModel = new ProjectAddFormModel()
                {
                    ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured! Please try again letar or contact an administrator.";

                return this.RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectAddFormModel model)
        {
            if (this.User.IsCustomer())
            {
                this.TempData[ErrorMessage] = "You must be a creator to add new Products";
                return this.RedirectToAction("Home", "Index");
            }

            bool categoryExist = await this.productProjectCategoryService.ExsistsByIdAsync(model.CategoryId);
            if (!categoryExist)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist");
            }

            if (!this.ModelState.IsValid)
            {
                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();

                return this.View(model);
            }

            try
            {
                string creatorId = User.GetId()!;
                string projectId = await this.projectService.CreateAndReturnIdAsync(model, creatorId);

                this.TempData[SuccessMessage] = "Product was added successfully";

                return this.RedirectToAction("AllProjects", "Project", new { id = projectId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();

                return this.View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool productExists = await projectService.ExistsByIdAsync(id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Project with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "ProdProjectuct");
            }

            if (this.User.IsCustomer() && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be Creator to edit Project";
                return this.RedirectToAction("AllProjects", "Project");
            }

            bool isCreatorOwner = await this.creatorService.HasProjectWithIdAsync(id, this.User.GetId()!);

            if (!isCreatorOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Creator owner to the Project in order to edit it.";
                return this.RedirectToAction("Mine", "Project");
            }

            try
            {
                ProjectEditFormModel formModel = await this.projectService
                .GetProjectForEditByIdAsync(id);
                formModel.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ProjectEditFormModel model)
        {

            if (!this.ModelState.IsValid)
            {
                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();
                return this.View(model);
            }

            bool productExists = await projectService.ExistsByIdAsync(id);

            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Project with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "Project");
            }

            if (this.User.IsCustomer() && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be Creator to edit Project";
                return this.RedirectToAction("AllProjects", "Project");
            }

            bool isCreatorOwner = await this.creatorService.HasProjectWithIdAsync(id, this.User.GetId()!);

            if (!isCreatorOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Creator owner to the Project in order to edit it.";
                return this.RedirectToAction("AllProjects", "Project");
            }

            try
            {
                await this.projectService.EditProjectByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                model.ProductProjectCategories = await this.productProjectCategoryService.AllProductProjectCategoryAsync();
                return this.View(model);

            }

            this.TempData[SuccessMessage] = "Project was edited successfully";

            return this.RedirectToAction("Details", "Project", new { id = id });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllProjectsInChallenge(string id)
        {
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
        public async Task<IActionResult> Participate(string id)
        {
            if (!this.User.IsCreator()) 
            {
                this.TempData[ErrorMessage] = "You must be Creator to participate in challenges";
                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                string userId = this.User.GetId()!;
                int categoryId = await this.challengeService.ReturnCategoryIdByChallengeIdAsync(id);

                IEnumerable<ProjectParticipateViewModel> projectsAllowed = await this.projectService.AllProjectsByCreatorIdAndChallengeCategorayIdAsync(userId, categoryId, id);

                if (!projectsAllowed.Any())
                {
                    this.TempData[ErrorMessage] = "You do not have any projects for this challenge category";
                    return this.RedirectToAction("Index", "Home");
                }

                return this.View(projectsAllowed);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Participate(ProjectParticipateViewModel model)
        {
            if (!this.User.IsCreator())
            {
                this.TempData[ErrorMessage] = "You must be Creator to participate in challenges";
                return this.RedirectToAction("Index", "Home");
            }

            bool projectExists = await projectService.ExistsByIdAsync(model.Id);

            if (!projectExists)
            {
                this.TempData[ErrorMessage] = "Project with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "Project");
            }

            bool challengeExists = await challengeService.ExistsByIdAsync(model.ChallengeId);

            if (!challengeExists)
            {
                this.TempData[ErrorMessage] = "Challenge with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "Project");
            }

            try
            {
                await this.challengeService.AddProductToChallengeAsync(model);

                this.TempData[SuccessMessage] = "Project entered successfully the Challenge";

                return this.RedirectToAction("AllProjectsInChallenge", "Project", new { id = model.ChallengeId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            if (!this.User.IsCreator())
            {
                this.TempData[ErrorMessage] = "You must be Creator to have Projects";
                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                IEnumerable<ProjectAllViewModel> allProjects = await this.projectService.GetAllByCreatorIdAsync(this.User.GetId()!);
                return this.View(allProjects);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool projectExists = await projectService.ExistsByIdAsync(id);

            if (!projectExists)
            {
                this.TempData[ErrorMessage] = "Project with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "Project");
            }

            try
            {
                ProjectDetailsViewModel viewModel = await this.projectService
                 .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            bool projectExists = await projectService.ExistsByIdAsync(id);

            if (!projectExists)
            {
                this.TempData[ErrorMessage] = "Project with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "Project");
            }


            if (this.User.IsCustomer() && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be Creator to delete Projects";
                return this.RedirectToAction("AllProjects", "Project");
            }

            bool isCreatorOwner = await this.creatorService.HasProjectWithIdAsync(id, this.User.GetId()!);

            if (!isCreatorOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Creator of the Project to delete it";
                return this.RedirectToAction("AllProjects", "Project");
            }

            try
            {
                await this.imageService.DeleteProductImagesByEntityCorrespondingIdAsync(id);
                await this.projectService.DeleteProductByIdAsync(id);

                this.TempData[WarningMessage] = "The Project was successfully deleted";
                return this.RedirectToAction("Mine", "Product");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Withdaw(string id)
        {
            bool projectExists = await projectService.ExistsByIdAsync(id);

            if (!projectExists)
            {
                this.TempData[ErrorMessage] = "Project with the provided ID does not exist";
                return this.RedirectToAction("AllProjects", "Project");
            }


            if (this.User.IsCustomer() && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be Creator to withdraw Projects";
                return this.RedirectToAction("AllProjects", "Project");
            }

            bool isCreatorOwner = await this.creatorService.HasProjectWithIdAsync(id, this.User.GetId()!);

            if (!isCreatorOwner && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the Creator of the Project to withdraw it";
                return this.RedirectToAction("AllProjects", "Project");
            }

            try
            {
                await this.projectService.WithdrawProjectWithIdFromChalengeAsync(id);

                this.TempData[WarningMessage] = "The Project was successfully withdrawn";
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
