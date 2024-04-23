using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Data;
using CarSelling.Data.Models;
using CarSelling.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Services.Data
{
    public class UserService:IUserService
    {
        private readonly CarSellingDbContext dbContext;

        public UserService(CarSellingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> FindNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
