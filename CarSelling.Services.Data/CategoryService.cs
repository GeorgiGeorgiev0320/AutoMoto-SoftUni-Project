using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Data;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly CarSellingDbContext dbContext;

        public CategoryService(CarSellingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<CategoryCarFormModel>> GetCategoriesAsync()
        {
            return await dbContext.Categories.Select(h => new CategoryCarFormModel()
            {
                Id = h.Id,
                Name = h.Name
            }).ToArrayAsync();
        }

        public async Task<bool> IsValidCategory(int id)
        {
            return await dbContext.Categories.AnyAsync(h => h.Id == id);
        }
    }
}
