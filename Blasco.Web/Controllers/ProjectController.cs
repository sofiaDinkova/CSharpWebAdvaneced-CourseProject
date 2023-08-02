namespace Blasco.Web.Controllers
{
    using Blasco.Services.Data.Interfaces;
    using Blasco.Web.ViewModels.Project;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllProjects(string id)
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
    }
}
