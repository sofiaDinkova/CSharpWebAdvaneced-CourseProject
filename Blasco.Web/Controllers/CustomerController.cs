namespace Blasco.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extentions;
    using Blasco.Services.Data.Interfaces;

    using static Common.NotificationMessagesConstents;
    using static Common.GeneralApplicationConstants;
    using Blasco.Web.ViewModels.Customer;
    using Blasco.Web.ViewModels.Creator;
    using Microsoft.AspNetCore.Identity;
    using Blasco.Data.Models;


    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ICustomerTypeService customerTypeService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> creatorManager;

        public CustomerController(ICustomerService customerService, UserManager<ApplicationUser> creatorManager)
        {
            this.customerService = customerService;
            this.creatorManager = creatorManager;
        }

        

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();

            bool isCustomer = await this.customerService.CustomerExistsByCreatorId(userId);

            if (isCustomer)
            {
                TempData[ErrorMessage] = "You are already a customer!";
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeCustomerFormModel model)
        {
            string? userId = this.User.GetId();

            bool isCustomer = await this.customerService.CustomerExistsByCreatorId(userId);

            if (isCustomer)
            {
                TempData[ErrorMessage] = "You are already a customer!";
                return this.RedirectToAction("Index", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            try
            {
                await this.customerService.Create(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured! Please try again letar or contact an administrator.";
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("AllProducts", "Products");
        }
    }
}
