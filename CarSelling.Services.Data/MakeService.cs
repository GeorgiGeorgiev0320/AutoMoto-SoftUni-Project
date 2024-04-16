using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Data;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.Make;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Services.Data
{
    public class MakeService : IMakeService
    {
        private readonly CarSellingDbContext dbContext;

        public MakeService(CarSellingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<MakeCarFormModel>> GetMakesAsync()
        {
            return await dbContext.Makes.Select(m => new MakeCarFormModel()
            {
                Id = m.Id,
                Make = m.MakeName
            }).ToArrayAsync();
        }

        public async Task<bool> IsValidMake(int id)
        {
            return await dbContext.Makes.AnyAsync(h => h.Id == id);
        }
    }
}
