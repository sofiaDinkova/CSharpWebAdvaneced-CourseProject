namespace Blasco.Web.Controllers
{
    using System.Diagnostics;
    using Blasco.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    using static Common.GeneralApplicationConstants;

    using ViewModels.Home;
    public class HomeController : Controller
    {
        private readonly IProjectService projectService;

        public HomeController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            IEnumerable<IndexViewModel> viewModel = await this.projectService.LastThreeProjectAsync();

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }

            if (statusCode == 401)
            {
                return this.View("Error401");
            }

            return View();
        }
    }
}