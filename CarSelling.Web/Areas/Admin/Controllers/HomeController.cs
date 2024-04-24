using Microsoft.AspNetCore.Mvc;

namespace CarSelling.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
