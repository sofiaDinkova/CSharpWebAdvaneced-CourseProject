namespace Blasco.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Blasco.Services.Data.Interfaces;
    using Blasco.Web.ViewModels.Creator;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModel = await this.userService.AllUsersAsync();

            return View(viewModel);
        }
    }
}
