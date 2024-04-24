using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CarSelling.Common.AppConstants;

namespace CarSelling.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [Route("User/All")]
        [ResponseCache (Duration = 30)]
        public async Task<IActionResult> All()
        {
            ICollection<UserViewModel> users =
                this.memoryCache.Get<ICollection<UserViewModel>>(UsersCacheKey);
            if (users == null)
            {
                users = await this.userService.AllUsersAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan
                        .FromMinutes(UsersCacheDurationMinutes));

                this.memoryCache.Set(UsersCacheKey, users, cacheOptions);
            }
            return View(users);
        }
    }
}
