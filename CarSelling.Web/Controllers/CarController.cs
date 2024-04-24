using CarSelling.Services.Data.Interfaces;
using CarSelling.Services.Data.Models.Car;
using CarSelling.Web.Infrastructure.Extensions;
using CarSelling.Web.ViewModels.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using static CarSelling.Common.NotificationMessagesConstants;
using static CarSelling.Common.AppConstants;

namespace CarSelling.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMakeService makeService;
        private readonly ISellerService sellerService;
        private readonly ICarService carService;
        private readonly IUserService userService;

        public CarController(ICategoryService categoryService, IMakeService makeService, ISellerService sellerService, ICarService carService, IUserService userService)
        {
            this.categoryService = categoryService;
            this.makeService = makeService;
            this.sellerService = sellerService;
            this.carService = carService;
            this.userService = userService;
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

                return RedirectToAction("Become", "Seller");
            }


            try
            {
                CarFormModel car = new CarFormModel()
                {
                    Categories = await categoryService.GetCategoriesAsync(),
                    Makes = await makeService.GetMakesAsync()
                };

                return View(car);
            }
            catch (Exception )
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel modelToModel)
        {
            bool isSeller = await sellerService.IsSellerEnabled(this.User.GetId()!);

            if (!isSeller)
            {
                TempData[ErrorMessage] = "You have to become seller to add cars!";

               return RedirectToAction("Become", "Seller");
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
                string carId = await carService.CreateCar(modelToModel, sellerId!);
                return RedirectToAction("Details", "Car", new {id=carId});

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }

            
        }

        public async Task<IActionResult> Mine()
        {

            if (User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Mine", "Car", new { Area = AdminAreaName });
            }
            ICollection<CarAllViewModel> allCars = new List<CarAllViewModel>();
            string userId = this.User.GetId()!;

            bool isUserSeller = await sellerService.IsSellerEnabled(userId);

            try
            {
                if (User.IsAdmin())
                {
                    string? agentId =
                        await this.sellerService.GetSellerIdByUsesId(userId);

                    allCars.AddRange(await this.carService.SellerCarsByIdAsync(agentId!));

                    
                    allCars.AddRange(await this.carService.UserBoughtCarsByIdAsync(userId));

                    allCars = allCars
                        .DistinctBy(h => h.Id)
                        .ToList();
                }
                else if (isUserSeller)
                {
                    string? sellerId = await sellerService.GetSellerIdByUsesId(userId);

                    allCars.AddRange(await carService.SellerCarsByIdAsync(sellerId!));
                }
                else
                {
                    allCars.AddRange(await carService.UserBoughtCarsByIdAsync(userId));
                }

                return View(allCars);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var carDetailsTry = await carService.CarDetailsByIdAsync(id);

            if (carDetailsTry == null)
            {
                TempData[ErrorMessage] = "Car with this id does not exist";

                return RedirectToAction("All", "Car");
            }


            try
            {
                var carDetails = await carService.CarDetailsByIdAsync(id);
                carDetails.Seller.FullName = await userService.FindNameByEmailAsync(User.Identity?.Name!);


                return View(carDetails);
            }
            catch (Exception e)
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool carExists = await carService.CarExistsByIdAsync(id);

            if (!carExists)
            {
                TempData[ErrorMessage] = "This car does not exists!";

                return RedirectToAction("All", "Car");
            }

            bool isSeller = await sellerService.IsSellerEnabled(User.GetId()!);

            if (!isSeller && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be seller to edit this vehicle!";
                return RedirectToAction("Become", "Seller");
            }

            string? sellerId = await sellerService.GetSellerIdByUsesId(User.GetId()!);

            bool isSellerOwner = await carService.IsSellerIdOwnerByIdAsync(sellerId!, id);

            if (!isSellerOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be owner of the vehicle to edit it!";

                return RedirectToAction("Mine", "Car");
            }

            try
            {
                var carToEdit = await carService.GetCarForEditAsync(id);

                carToEdit.Categories = await categoryService.GetCategoriesAsync();
                carToEdit.Makes = await makeService.GetMakesAsync();


                return View(carToEdit);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, CarFormModel editedCar)
        {

            if (!ModelState.IsValid)
            {
                editedCar.Categories = await categoryService.GetCategoriesAsync();
                editedCar.Makes = await makeService.GetMakesAsync();

                return View(editedCar);
            }
            bool carExists = await carService.CarExistsByIdAsync(id);

            if (!carExists)
            {
                TempData[ErrorMessage] = "This car does not exists!";

                return RedirectToAction("All", "Car");
            }

            bool isSeller = await sellerService.IsSellerEnabled(User.GetId()!);

            if (!isSeller && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be seller to edit this vehicle!";
                return RedirectToAction("Become", "Seller");
            }
            string? sellerId = await sellerService.GetSellerIdByUsesId(User.GetId()!);

            bool isSellerOwner = await carService.IsSellerIdOwnerByIdAsync(sellerId!, id);

            if (!isSellerOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be owner of the vehicle to edit it!";

                return RedirectToAction("Mine", "Car");
            }



            try
            {
                await carService.EditCarByIdAsync(id, editedCar);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occured. Try again later!");

                editedCar.Categories = await categoryService.GetCategoriesAsync();
                editedCar.Makes = await makeService.GetMakesAsync();

                return View(editedCar);
            }

            TempData[SuccessMessage] = "Cat edited successfully!";
            return RedirectToAction("Details", "Car", new{id});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool carExists = await carService.CarExistsByIdAsync(id);

            if (!carExists)
            {
                TempData[ErrorMessage] = "This car does not exists!";

                return RedirectToAction("All", "Car");
            }

            bool isSeller = await sellerService.IsSellerEnabled(User.GetId()!);

            if (!isSeller && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be seller to delete this vehicle!";
                return RedirectToAction("Become", "Seller");
            }
            string? sellerId = await sellerService.GetSellerIdByUsesId(User.GetId()!);

            bool isSellerOwner = await carService.IsSellerIdOwnerByIdAsync(sellerId!, id);

            if (!isSellerOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be owner of the vehicle to delete it!";

                return RedirectToAction("Mine", "Car");
            }

            try
            {
                var car = await carService.DeleteCarModelByIdAsync(id);
                return View(car);
            }
            catch (Exception )
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, CarDeleteModel carDelete)
        {
            bool carExists = await carService.CarExistsByIdAsync(id);

            if (!carExists)
            {
                TempData[ErrorMessage] = "This car does not exists!";

                return RedirectToAction("All", "Car");
            }

            bool isSeller = await sellerService.IsSellerEnabled(User.GetId()!);

            if (!isSeller && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be seller to delete this vehicle!";
                return RedirectToAction("Become", "Seller");
            }
            string? sellerId = await sellerService.GetSellerIdByUsesId(User.GetId()!);

            bool isSellerOwner = await carService.IsSellerIdOwnerByIdAsync(sellerId!, id);

            if (!isSellerOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be owner of the vehicle to delete it!";

                return RedirectToAction("Mine", "Car");
            }

            try
            {
                await carService.DeleteCarByIdAsync(id);
                TempData[WarningMessage] = "The car has been deleted!";
                return RedirectToAction("Mine");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Buy(string id)
        {
            var carExists = await carService.CarExistsByIdAsync(id);
            if (!carExists)
            {
                TempData[ErrorMessage] = "Car with the given Id does not exists!";

                return RedirectToAction("All", "Car");
            }

            var carIsBought = await carService.IsBought(id);
            if (carIsBought)
            {
                TempData[ErrorMessage] = "Car with the given Id is already bought!";
                return RedirectToAction("All", "Car");
            }

            bool isSeller = await sellerService.IsSellerEnabled(User.GetId()!);
            if (isSeller && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be User to buy cars!";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await carService.BuyCar(User.GetId()!, id);
                return RedirectToAction("Mine", "Car");
            }
            catch (Exception )
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Sell(string id)
        {
            var carExists = await carService.CarExistsByIdAsync(id);
            if (!carExists)
            {
                TempData[ErrorMessage] = "Car with the given Id does not exists!";

                return RedirectToAction("All", "Car");
            }

            var carIsBought = await carService.IsBought(id);
            if (!carIsBought)
            {
                TempData[ErrorMessage] = "Car with the given Id not bought!";
                return RedirectToAction("Mine", "Car");
            }

            var userCart = await carService.IsBoughtByUserIdAsync(id,User.GetId()!);
            if (!userCart)
            {
                TempData[ErrorMessage] = "Car with the given Id not yours!";
                return RedirectToAction("Mine", "Car");
            }

            try
            {
                await carService.SellCarAsync(id);
                return RedirectToAction("Mine", "Car");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occured! Try again later!";

                return RedirectToAction("Index", "Home");
            }
        }

    }
}
