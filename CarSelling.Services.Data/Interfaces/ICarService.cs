using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Services.Data.Models.Car;
using CarSelling.Web.ViewModels.Car;
using CarSelling.Web.ViewModels.Home;

namespace CarSelling.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<ICollection<IndexViewModel>> LastFewCars();

        Task<string> CreateCar(CarFormModel model, string sellerId);

        Task<AllCarsFilteredServiceModel> AllCarsFiltered(CarsAllQueryModel queryModel);

        Task<ICollection<CarAllViewModel>> SellerCarsByIdAsync(string id);

        Task<ICollection<CarAllViewModel>> UserBoughtCarsByIdAsync(string id);

        Task<CarDetailsViewModel?> CarDetailsByIdAsync(string id);

        Task<bool> CarExistsByIdAsync(string id);

        Task<bool> IsSellerIdOwnerByIdAsync(string sellerId,string id);

        Task EditCarByIdAsync(string id, CarFormModel car);

        Task<CarFormModel> GetCarForEditAsync(string id);

        Task<CarDeleteModel> DeleteCarModelByIdAsync(string carId);

        Task DeleteCarByIdAsync(string id);
    }
}
