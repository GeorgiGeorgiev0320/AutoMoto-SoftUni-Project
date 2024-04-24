using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.Buy;
using Microsoft.AspNetCore.Mvc;

namespace CarSelling.Web.Areas.Admin.Controllers
{
    public class BuyController : BaseAdminController
    {
        private readonly IBuyService buyService;

        public BuyController(IBuyService buyService)
        {
            this.buyService = buyService;
        }

        [Route("Buy/All")]
        public async Task<IActionResult> All()
        {
            ICollection<BuyViewModel> allBuys = await buyService.AllAsync();

            return View(allBuys);
        }
    }
}
