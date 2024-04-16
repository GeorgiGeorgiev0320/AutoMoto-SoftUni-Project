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
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new List<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Cars And SUVs"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Motorbikes"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Semi Trucks and Buses"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Boats and Yachts"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
