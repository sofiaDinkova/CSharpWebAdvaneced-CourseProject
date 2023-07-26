namespace Blasco.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ProjectController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> AllProjects()
        {
            return View();
        }
    }
}
