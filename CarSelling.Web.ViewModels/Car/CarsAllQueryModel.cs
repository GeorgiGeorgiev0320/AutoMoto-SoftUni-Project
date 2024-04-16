
using System.ComponentModel.DataAnnotations;

using CarSelling.Web.ViewModels.Car.Enums;

using static CarSelling.Common.AppConstants;

namespace CarSelling.Web.ViewModels.Car
{
    public class CarsAllQueryModel
    {
        public string? Category { get; set; }

        public string? Make { get; set; }

        [Display(Name = "Search by keyword")]
        public string? Search { get; set; }

        public CarSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = DefaultPage;

        public int CarPerPage { get; set; } = DefaultCarsPPage;

        public int TotalCars { get; set; }

        public ICollection<string> Categories { get; set; } = new List<string>();

        public ICollection<string> Makes { get; set; } = new List<string>();

        public ICollection<CarAllViewModel> AllCars { get; set; } = new List<CarAllViewModel>();
    }
}
