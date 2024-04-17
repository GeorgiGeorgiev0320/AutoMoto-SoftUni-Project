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

        public async Task CreateCar(CarFormModel model, string sellerId)
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
            var sellerCars = await dbContext.Cars.Where(c => c.BuyerId.ToString() == id).Select(x => new CarAllViewModel
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
            var userCars = await dbContext.Cars.Where(c => c.BuyerId.HasValue && c.BuyerId.ToString() == id).Select(x => new CarAllViewModel
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
