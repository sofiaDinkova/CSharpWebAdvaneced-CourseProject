namespace Blasco.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extentions;
    using Blasco.Services.Data.Interfaces;

    using static Common.NotificationMessagesConstents;
    using Blasco.Web.ViewModels.Customer;

    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
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
