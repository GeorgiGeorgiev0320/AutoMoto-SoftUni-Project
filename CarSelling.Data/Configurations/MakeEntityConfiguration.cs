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
    public class MakeEntityConfiguration: IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasData(this.GenerateMakes());
        }

        private Make[] GenerateMakes()
        {
            ICollection<Make> makes = new List<Make>();

            Make make;

            make = new Make()
            {
                Id = 1,
                MakeName = "BMW"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 2,
                MakeName = "Audi"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 3,
                MakeName = "Toyota"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 4,
                MakeName = "Honda"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 5,
                MakeName = "Volkswagen"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 6,
                MakeName = "Mercedes-Benz"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 7,
                MakeName = "Nissan"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 8,
                MakeName = "Tesla"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 9,
                MakeName = "Ford"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 10,
                MakeName = "Kia"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 11,
                MakeName = "Hyundai"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 12,
                MakeName = "Subaru"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 13,
                MakeName = "Fiat"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 14,
                MakeName = "Volvo"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 15,
                MakeName = "Porsche"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 16,
                MakeName = "Jaguar"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 17,
                MakeName = "Land Rover"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 18,
                MakeName = "Mazda"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 19,
                MakeName = "Mitsubishi"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 20,
                MakeName = "Rolls-Royce"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 21,
                MakeName = "Bentley"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 22,
                MakeName = "Ferrari"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 23,
                MakeName = "Lamborghini"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 24,
                MakeName = "Koenigsegg"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 25,
                MakeName = "Chevrolet"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 26,
                MakeName = "Dodge"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 27,
                MakeName = "Cadillac"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 28,
                MakeName = "Lada"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 29,
                MakeName = "Mini Cooper"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 30,
                MakeName = "GMC"
            };
            makes.Add(make);
            make = new Make()
            {
                Id = 31,
                MakeName = "Bugatti"
            };
            makes.Add(make);

            return makes.ToArray();
        }
    }
}
