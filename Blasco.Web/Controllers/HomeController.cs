namespace Blasco.Web.Controllers
{
    using System.Diagnostics;
    using Blasco.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<IndexViewModel> viewModel = await this.projectService.LastThreeProjectAsync();

            return View(viewModel);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}