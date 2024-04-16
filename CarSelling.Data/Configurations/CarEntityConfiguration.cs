using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSelling.Data.Configurations
{
    public class CarEntityConfiguration: IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Seller)
                .WithMany(c => c.CarsForSelling)
                .HasForeignKey(c => c.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Make)
                .WithMany(m => m.Cars)
                .HasForeignKey(f => f.MakeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateCars());
        }

        private Car[] GenerateCars()
        {
            ICollection<Car> cars = new List<Car>();

            Car car;

            car = new Car()
            {
                MakeId = 1,
                Model = "5 series",
                Description = "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/df/BMW_5er-E60.jpg",
                Price = 13000.00M,
                CategoryId = 1,
                SellerId = Guid.Parse("A3573AF0-47BD-495E-A90A-B5941782C088"),
                BuyerId = Guid.Parse("A3116CF0-1ED6-4C4C-2BC8-08DC5CB89100")

            };
            cars.Add(car);
            car = new Car()
            {
                MakeId = 2,
                Model = "A6",
                Description = "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!",
                ImageUrl = "https://autobild.bg/wp-content/uploads/2018/01/Gebrauchte-Edel-Kombis-bis-10-000-Euro-1200x800-91458492c53dfda5.jpg",
                Price = 27000.00M,
                CategoryId = 1,
                SellerId = Guid.Parse("A3573AF0-47BD-495E-A90A-B5941782C088")
            };
            cars.Add(car);
            car = new Car()
            {
                MakeId = 6,
                Model = "Mercedes-benz bus",
                Description = "Spacious bus with really comfortable seat, good music and pretty stewardess for your long journeys!",
                ImageUrl = "https://www.daimlertruck.com/fileadmin/press/6/5/D652811/cms.jpeg",
                Price = 123000.00M,
                CategoryId = 3,
                SellerId = Guid.Parse("A3573AF0-47BD-495E-A90A-B5941782C088")

            };
            cars.Add(car);

            return cars.ToArray();
        }
    }
}
