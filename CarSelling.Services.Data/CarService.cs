using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Data;
using CarSelling.Data.Models;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.Car;
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
                CreatedOn = DateTime.UtcNow
            };

            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<IndexViewModel>> LastFewCars()
        {
            ICollection<IndexViewModel> LastCars = await dbContext.Cars.OrderByDescending(h => h.CreatedOn).Take(3)
                .Select(c => new IndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Make = c.Make.MakeName,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl
                }).ToArrayAsync();
            return LastCars;
        }
    }
}
