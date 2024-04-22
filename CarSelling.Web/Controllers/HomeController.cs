
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.Home;

namespace CarSelling.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<IndexViewModel> cars = await carService.LastFewCars();

            return View(cars);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }


            return View();
        }
    }
}