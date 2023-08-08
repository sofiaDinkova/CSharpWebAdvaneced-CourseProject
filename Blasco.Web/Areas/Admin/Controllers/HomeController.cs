using Microsoft.AspNetCore.Mvc;

namespace Blasco.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        //[Route("Admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
