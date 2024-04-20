using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Web.ViewModels.Seller;

namespace CarSelling.Web.ViewModels.Car
{
    public class CarDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Category{ get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public bool IsBought { get; set; }

        public SellerDetailsViewModel Seller { get; set; } = null!;
    }
}
