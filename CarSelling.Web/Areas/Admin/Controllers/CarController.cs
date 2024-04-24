using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.Areas.Admin.ViewModels.Car;
using CarSelling.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CarSelling.Web.Areas.Admin.Controllers
{
    public class CarController : BaseAdminController
    {
        private readonly ISellerService sellerService;
        private readonly ICarService carService;

        public CarController(ISellerService sellerService, ICarService carService)
        {
            this.sellerService = sellerService;
            this.carService = carService;
        }

        public async Task<IActionResult> Mine()
        {
            string? sellerId = await sellerService.GetSellerIdByUsesId(User.GetId()!);
            MyCarsViewModel viewModel = new MyCarsViewModel()
            {
                AddedCars = await carService.SellerCarsByIdAsync(sellerId!),
                BoughtCars = await carService.UserBoughtCarsByIdAsync(User.GetId()!)
            };

            return View(viewModel);
        }
    }
}
