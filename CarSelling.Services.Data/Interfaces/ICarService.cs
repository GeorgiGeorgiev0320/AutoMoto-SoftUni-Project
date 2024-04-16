using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Web.ViewModels.Car;
using CarSelling.Web.ViewModels.Home;

namespace CarSelling.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<ICollection<IndexViewModel>> LastFewCars();

        Task CreateCar(CarFormModel model, string sellerId);
    }
}
