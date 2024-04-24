using System.Security.Cryptography.X509Certificates;
using CarSelling.Data;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Services.Mapping;
using CarSelling.Web.ViewModels.Buy;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Services.Data
{
    public class BuyService:IBuyService
    {
        private readonly CarSellingDbContext dbContext;

        public BuyService(CarSellingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<BuyViewModel>> AllAsync()
        {
            var allBuys = await dbContext
                .Cars
                .Include(c => c.Buyer)
                .Include(c => c.Seller)
                .ThenInclude(c => c.User)
                .Include(c=>c.Make)
                .Where(u => u.BuyerId.HasValue)
                .Select(c => new BuyViewModel
                {
                    MakeName = c.Make.MakeName,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    SellerFullName = $"{c.Seller.User.FirstName} {c.Seller.User.LastName}",
                    SellerEmail = c.Seller.User.Email,
                    BuyerFullName = $"{c.Buyer!.FirstName} {c.Buyer.LastName}",
                    BuyerEmail = c.Buyer.Email,

                })
                .ToArrayAsync();


               
            return allBuys;
        }
    }
}
