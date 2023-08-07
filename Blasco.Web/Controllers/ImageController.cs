using Blasco.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blasco.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        //[HttpGet]
        //public IActionResult Upload()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Upload(List<IFormFile> files)
        //{
        //    await imageService.InsertImagesAsync(files);
        //    return RedirectToAction("Index");
        //}
    }
}
