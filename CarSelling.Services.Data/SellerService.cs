using CarSelling.Data;
using CarSelling.Data.Models;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.Seller;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Services.Data
{
    public class SellerService : ISellerService
    {
        private readonly CarSellingDbContext dbContext;

        public SellerService(CarSellingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> IsSellerEnabled(string id)
        {
            bool result = await dbContext
                .Sellers
                .AnyAsync(s => s.UserId.ToString() == id);

            return result;
        }

        public async Task<bool> SellerNumberAlreadyInUseAsync(string phoneNumber)
        {
            bool result = await dbContext.Sellers.AnyAsync(s => s.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task Create(string userId, SellerFormModel model)
        {
            Seller seller;

            seller = new Seller()
            {
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);
            user!.PhoneNumber = model.PhoneNumber;
            user.PhoneNumberConfirmed = true;
            await dbContext.Sellers.AddAsync(seller);
            await dbContext.SaveChangesAsync();
        }

        public async Task<string?> GetSellerIdByUsesId(string userId)
        {
            Seller? seller = await dbContext.Sellers.FirstOrDefaultAsync(f => f.UserId.ToString() == userId);
            if (seller == null)
            {
                return null;
            }

            return seller.Id.ToString();
        }

        public async Task<bool> HasCarByIdAsync(string userId, string carId)
        {
            Seller? seller = await dbContext.Sellers.Include(c=>c.CarsForSelling).FirstOrDefaultAsync(f => f.UserId.ToString() == userId);

            if (seller == null)
            {
                return false;
            }
            return seller.CarsForSelling.Any(c => c.Id.ToString() == carId.ToLower());
        }
    }
}
