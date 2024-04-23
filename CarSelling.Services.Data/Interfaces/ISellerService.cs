using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Web.ViewModels.Seller;

namespace CarSelling.Services.Data.Interfaces
{
    public interface ISellerService
    {
        Task<bool> IsSellerEnabled(string id);

        Task<bool> SellerNumberAlreadyInUseAsync(string phoneNumber);

        Task Create(string userId, SellerFormModel model);

        Task<string?> GetSellerIdByUsesId(string userId);

        Task<bool> HasCarByIdAsync(string userId, string carId);
    }
}
