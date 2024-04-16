
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}