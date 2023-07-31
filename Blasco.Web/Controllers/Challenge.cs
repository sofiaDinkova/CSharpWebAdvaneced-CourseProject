using Blasco.Services.Data.Models.Product;
using Blasco.Services.Data.Models.Project;
using Blasco.Web.ViewModels.Product;
using Blasco.Web.ViewModels.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blasco.Web.Controllers
{
    [Authorize]
    public class Challenge : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllChallenges()
        {
            return this.View();
            //try
            //{
            //    AllProjectsChallengeModel challengeServiceModel 

            //    ProjectChallegeViewModel;
            //    AllProductsFilteredAndPagedModel serviceModel = await this.productService.AllAsync(queryModel);

            //    queryModel.Products = serviceModel.Products;
            //    queryModel.TotalProducts = serviceModel.TotalProductsCount;
            //    queryModel.Categories = await this.productProjectCategoryService.AllProductProjectCategoryNamesAsync();

            //    return this.View(queryModel);
            //}
            //catch (Exception)
            //{
            //    return this.GeneralError();
            //}
        }
    }
}
