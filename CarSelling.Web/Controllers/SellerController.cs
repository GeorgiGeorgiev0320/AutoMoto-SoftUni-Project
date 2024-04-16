using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.Infrastructure.Extensions;
using CarSelling.Web.ViewModels.Seller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarSelling.Common.NotificationMessagesConstants;

namespace CarSelling.Web.Controllers
{
    [Authorize]
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isAgent = await sellerService.IsSellerEnabled(userId);

            if (isAgent)
            {
                TempData[ErrorMessage] = "Ding dong, you are already a seller!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(SellerFormModel model)
        {
            string? userId = this.User.GetId();
            bool isAgent = await sellerService.IsSellerEnabled(userId);

            if (isAgent)
            {
                TempData[ErrorMessage] = "Ding dong, you are already a seller!";

                return RedirectToAction("Index", "Home");
            }

            bool numberUsed = await sellerService.SellerNumberAlreadyInUseAsync(model.PhoneNumber);
            if (numberUsed)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Seller with this number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            try
            {

                await sellerService.Create(userId, model);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("All", "Car");
        }
    }
}
