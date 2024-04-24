using CarSelling.Data;
using CarSelling.Data.Models;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Services.Data
{
    public class UserService:IUserService
    {
        private readonly ISellerService sellerService;
        private readonly CarSellingDbContext dbContext;

        public UserService(CarSellingDbContext dbContext, ISellerService sellerService)
        {
            this.dbContext = dbContext;
            this.sellerService = sellerService;
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

        public async Task<ICollection<UserViewModel>> AllUsersAsync()
        {
            var allUsers = await dbContext.Users.Select(u => new UserViewModel()
            {
                Email = u.Email,
                FullName = $"{u.FirstName} {u.LastName}",
                Id = u.Id.ToString(),
                PhoneNumber = u.PhoneNumber
            }).ToArrayAsync();
            return allUsers;
        }
    }
}
