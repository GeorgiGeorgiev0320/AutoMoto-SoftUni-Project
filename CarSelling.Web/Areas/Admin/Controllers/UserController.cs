using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace CarSelling.Web.Areas.Admin.Controllers
{
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
            ICollection<UserViewModel> allUsers = await userService.AllUsersAsync();

            return View(allUsers);
        }
    }
}
