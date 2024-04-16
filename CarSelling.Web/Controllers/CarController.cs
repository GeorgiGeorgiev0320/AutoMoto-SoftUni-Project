using CarSelling.Services.Data.Interfaces;
using CarSelling.Services.Data.Models.Car;
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
        private readonly ICarService carService;

        public CarController(ICategoryService categoryService, IMakeService makeService, ISellerService sellerService, ICarService carService)
        {
            this.categoryService = categoryService;
            this.makeService = makeService;
            this.sellerService = sellerService;
            this.carService = carService;
        }


        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]CarsAllQueryModel queryModel)
        {
            AllCarsFilteredServiceModel serviceModel = await carService.AllCarsFiltered(queryModel);


            queryModel.AllCars = serviceModel.Cars;
            queryModel.TotalCars = serviceModel.TotalCarsCount;
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();
            queryModel.Makes = await makeService.AllMakeNamesAsync();

            return View(queryModel);
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


        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel modelToModel)
        {
            bool isSeller = await sellerService.IsSellerEnabled(this.User.GetId()!);

            if (!isSeller)
            {
                TempData[ErrorMessage] = "You have to become seller to add cars!";

                RedirectToAction("Become", "Seller");
            }

            bool validCategory = await categoryService.IsValidCategory(modelToModel.CategoryId);
            bool validMake = await makeService.IsValidMake(modelToModel.MakeId);

            if (!validMake)
            {
                ModelState.AddModelError(nameof(modelToModel.MakeId), "The selection is not valid!");
            }
            if (!validCategory)
            {
                ModelState.AddModelError(nameof(modelToModel.CategoryId), "The selection is not valid!");
            }

            if (!ModelState.IsValid)
            {
                modelToModel.Categories = await categoryService.GetCategoriesAsync();
                modelToModel.Makes = await makeService.GetMakesAsync();

                return View(modelToModel);
            }

            try
            {
                string? sellerId = await sellerService.GetSellerIdByUsesId(this.User.GetId()!);
                await carService.CreateCar(modelToModel, sellerId!);

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
