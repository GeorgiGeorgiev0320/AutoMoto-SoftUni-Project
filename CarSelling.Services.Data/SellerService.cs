using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
