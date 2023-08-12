namespace Blasco.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseAdminController
    {
        //[Route("Admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
