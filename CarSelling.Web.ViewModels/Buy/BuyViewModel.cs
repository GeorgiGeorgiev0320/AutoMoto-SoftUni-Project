using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Services.Mapping;

namespace CarSelling.Web.ViewModels.Buy
{
    public class BuyViewModel
    {
        public string MakeName { get; set; } = null!;
        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string SellerFullName { get; set; } = null!;

        public string SellerEmail { get; set; } = null!;

        public string BuyerFullName { get; set; } = null!;

        public string BuyerEmail { get; set; } = null!;
    }
}
