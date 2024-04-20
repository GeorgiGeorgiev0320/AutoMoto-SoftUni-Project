using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Data;
using CarSelling.Data.Models;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Services.Data.Models.Car;
using CarSelling.Web.ViewModels.Car;
using CarSelling.Web.ViewModels.Car.Enums;
using CarSelling.Web.ViewModels.Home;
using CarSelling.Web.ViewModels.Seller;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Services.Data
{
    public class CarService : ICarService
    {
        private readonly CarSellingDbContext dbContext;

        public CarService(CarSellingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllCarsFilteredServiceModel> AllCarsFiltered(CarsAllQueryModel queryModel)
        {
            IQueryable<Car> carsQuery = dbContext.Cars.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category) && !string.IsNullOrWhiteSpace(queryModel.Make))
            {
                carsQuery = carsQuery.Where(h => h.Category.Name == queryModel.Category && h.Make.MakeName == queryModel.Make);
            }
            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                carsQuery = carsQuery.Where(h => h.Category.Name == queryModel.Category);
            }
            if (!string.IsNullOrWhiteSpace(queryModel.Make))
            {
                carsQuery = carsQuery.Where(h => h.Make.MakeName == queryModel.Make);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.Search))
            {
                string wildCard = $"%{queryModel.Search.ToLower()}%";

                carsQuery = carsQuery.Where(c=> EF.Functions.Like(c.Model, wildCard)||
                                                EF.Functions.Like(c.Description, wildCard));

            }

            carsQuery = queryModel.Sorting switch
            {
                CarSorting.PriceAscending => carsQuery.OrderBy(c => c.Price),
                CarSorting.PriceDescending => carsQuery.OrderByDescending(c => c.Price),
                CarSorting.Newest => carsQuery.OrderByDescending(c => c.Year),
                CarSorting.Oldest => carsQuery.OrderBy(c => c.Year),
                CarSorting.LastAdded => carsQuery.OrderByDescending(c => c.CreatedOn),
                CarSorting.FirstAdded => carsQuery.OrderBy(c => c.CreatedOn),
                CarSorting.BoughtCars => carsQuery.OrderBy(c => c.BuyerId != null).ThenByDescending(c=>c.CreatedOn)
            };

            ICollection<CarAllViewModel> allCars = await carsQuery
                .Where(h=>h.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.CarPerPage)
                .Take(queryModel.CarPerPage)
                .Select(c => new CarAllViewModel()
                {
                    Id = c.Id.ToString(),
                    Mileage = c.Mileage,
                    Date = c.Year.ToString("Y"),
                    MakeName = c.Make.MakeName,
                    Model = c.Model,
                    Price = c.Price,
                    IsBought = c.BuyerId.HasValue,
                    ImageUrl = c.ImageUrl
                }).ToArrayAsync();

            int totalCars = carsQuery.Count();

            return new AllCarsFilteredServiceModel()
            {
                Cars = allCars,
                TotalCarsCount = totalCars
            };
        }

        public async Task<string> CreateCar(CarFormModel model, string sellerId)
        {
            Car car = new Car()
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                MakeId = model.MakeId,
                Model = model.Model,
                HorsePower = model.HorsePower,
                Mileage = model.Mileage,
                SellerId = Guid.Parse(sellerId),
                Year = model.Year,
                Price = model.Price,
                CreatedOn = DateTime.Now
            };

            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();

            return car.Id.ToString();
        }

        public async Task<CarDetailsViewModel?> CarDetailsByIdAsync(string id)
        {
            Car? carFound = await dbContext.Cars
                .Include(c=>c.Category)
                .Include(c=>c.Make)
                .Include(c=>c.Seller).ThenInclude(s=>s.User)
                .Where(c => c.IsActive)
                .FirstOrDefaultAsync(c => c.Id.ToString() == id);

            if (carFound == null)
            {
                return null;
            }
            
            return  new CarDetailsViewModel
            {
                Id = carFound.Id.ToString(),
                Make = carFound.Make.MakeName,
                Category = carFound.Category.Name,
                Description = carFound.Description,
                Model = carFound.Model,
                Date = carFound.Year.ToString("yyyy-MM-dd"),
                ImageUrl = carFound.ImageUrl,
                Price = carFound.Price,
                Mileage = carFound.Mileage,
                IsBought = carFound.IsBought,
                Seller = new SellerDetailsViewModel()
                {
                    Address = carFound.Seller.Address,
                    Email = carFound.Seller.User.Email,
                    Number = carFound.Seller.PhoneNumber
                }
            };
        }

        public async Task<bool> CarExistsByIdAsync(string id)
        {

            bool result = await dbContext.Cars.AnyAsync(c => c.Id.ToString() == id);

            return result;
        }

        public async Task<bool> IsSellerIdOwnerByIdAsync(string sellerId, string id)
        {
            bool result = await dbContext.Cars.AnyAsync(s => s.SellerId.ToString() == sellerId && s.Id.ToString() == id);

            return result;
        }

        public async Task EditCarByIdAsync(string id, CarFormModel car)
        {
            var carToEdit = await dbContext.Cars.Where(c=>c.IsActive).FirstAsync(c => c.Id.ToString() == id);

            carToEdit.CategoryId = car.CategoryId;
            carToEdit.Description = car.Description;
            carToEdit.MakeId = car.MakeId;
            carToEdit.HorsePower = car.HorsePower;
            carToEdit.Mileage = car.Mileage;
            carToEdit.ImageUrl = car.ImageUrl;
            carToEdit.Price = car.Price;
            carToEdit.Model = car.Model;
            carToEdit.Year = car.Year;

            await dbContext.SaveChangesAsync();
        }

        public async Task<CarFormModel> GetCarForEditAsync(string id)
        {
            Car? carToEdit = await dbContext.Cars
                .Include(c => c.Category)
                .Include(c => c.Make)
                .Where(c => c.IsActive)
                .FirstOrDefaultAsync(c => c.Id.ToString() == id);

            var car = new CarFormModel
            {
                MakeId = carToEdit.MakeId,
                CategoryId = carToEdit.CategoryId,
                Model = carToEdit.Model,
                Mileage = carToEdit.Mileage,
                HorsePower = carToEdit.HorsePower,
                Description = carToEdit.Description,
                ImageUrl = carToEdit.ImageUrl,
                Price = carToEdit.Price,
                Year = carToEdit.Year,

            };


            return car;
        }

        public async Task<ICollection<IndexViewModel>> LastFewCars()
        {
            ICollection<IndexViewModel> lastCars = await dbContext.Cars
                .Where(h=>h.IsActive)
                .OrderByDescending(h => h.CreatedOn)
                .Take(3)
                .Select(c => new IndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Make = c.Make.MakeName,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl
                }).ToArrayAsync();
            return lastCars;
        }

        public async Task<ICollection<CarAllViewModel>> SellerCarsByIdAsync(string id)
        {
            var sellerCars = await dbContext.Cars.Where(c => c.SellerId.ToString() == id && c.IsActive == true).Select(x => new CarAllViewModel
            {
                Id = x.Id.ToString(),
                MakeName = x.Make.MakeName,
                Model = x.Model,
                Date = x.Year.ToString("yyyy-MM-dd"),
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Mileage = x.Mileage,
                IsBought = x.IsBought
            }).ToArrayAsync();

            return sellerCars;
        }

        public async Task<ICollection<CarAllViewModel>> UserBoughtCarsByIdAsync(string id)
        {
            var userCars = await dbContext.Cars.Where(c => c.IsBought==true && c.BuyerId.ToString() == id && c.IsActive==true).Select(x => new CarAllViewModel
            {
                Id = x.Id.ToString(),
                MakeName = x.Make.MakeName,
                Model = x.Model,
                Date = x.Year.ToString("yyyy-MM-dd"),
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Mileage = x.Mileage,
                IsBought = x.IsBought
            }).ToArrayAsync();

            return userCars;
        }
    }
}
