using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSelling.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
