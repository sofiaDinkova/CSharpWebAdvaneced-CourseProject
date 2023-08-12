namespace Blasco.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;

    using Services.Data.Interfaces;
    using Data.Models;

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
    }
}
