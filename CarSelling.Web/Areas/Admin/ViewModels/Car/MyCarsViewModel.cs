using CarSelling.Web.ViewModels.Car;

namespace CarSelling.Web.Areas.Admin.ViewModels.Car
{
    public class MyCarsViewModel
    {
        public ICollection<CarAllViewModel> AddedCars { get; set; } = null!;

        public ICollection<CarAllViewModel> BoughtCars { get; set; } = null!;
    }
}
