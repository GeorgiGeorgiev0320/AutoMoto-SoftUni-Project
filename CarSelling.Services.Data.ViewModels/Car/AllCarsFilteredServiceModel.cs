using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Web.ViewModels.Car;

namespace CarSelling.Services.Data.Models.Car
{
    public class AllCarsFilteredServiceModel
    {
        public int TotalCarsCount { get; set; }

        public ICollection<CarAllViewModel> Cars { get; set; } = new List<CarAllViewModel>();
    }
}
