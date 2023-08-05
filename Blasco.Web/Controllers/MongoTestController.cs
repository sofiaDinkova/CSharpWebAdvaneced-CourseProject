using Microsoft.AspNetCore.Mvc;

namespace Blasco.Web.Controllers
{
    public class MongoTestController : Controller
    {
        public IActionResult ReturnImage()
        {
            // Get image path
            string imgPath = ".\\image.jpg";
            // Convert image to byte array
            //byte[] binaryContent = File.ReadAllBytes("image.jpg");
            byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
            //Convert byte arry to base64string
            string imreBase64Data = Convert.ToBase64String(byteData);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            //Passing image data in viewbag to view
            ViewBag.ImageData = imgDataURL;
            return View();
        }
    }
}
