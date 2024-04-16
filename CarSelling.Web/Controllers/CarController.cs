using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.Infrastructure.Extensions;
using CarSelling.Web.ViewModels.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarSelling.Common.NotificationMessagesConstants;

namespace CarSelling.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMakeService makeService;
        private readonly ISellerService sellerService;

        public CarController(ICategoryService categoryService, IMakeService makeService, ISellerService sellerService)
        {
            this.categoryService = categoryService;
            this.makeService = makeService;
            this.sellerService = sellerService;
        }


        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isSeller = await sellerService.IsSellerEnabled(this.User.GetId()!);

            if (!isSeller)
            {
                TempData[ErrorMessage] = "You have to become seller to add cars!";

                RedirectToAction("Become", "Seller");
            }

            CarFormModel car = new CarFormModel()
            {
                Categories = await categoryService.GetCategoriesAsync(),
                Makes = await makeService.GetMakesAsync()
            };

            return View(car);
        }
    }
}
