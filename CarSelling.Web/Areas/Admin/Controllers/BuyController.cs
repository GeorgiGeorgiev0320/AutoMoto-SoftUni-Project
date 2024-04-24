using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.ViewModels.Buy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using static CarSelling.Common.AppConstants;

namespace CarSelling.Web.Areas.Admin.Controllers
{
    public class BuyController : BaseAdminController
    {
        private readonly IBuyService buyService;
        private readonly IMemoryCache memoryCache;

        public BuyController(IBuyService buyService, IMemoryCache memoryCache)
        {
            this.buyService = buyService;
            this.memoryCache = memoryCache;
        }

        [Route("Buy/All")]
        [ResponseCache(Duration = 90, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> All()
        {
            ICollection<BuyViewModel> allBuys = memoryCache.Get<ICollection<BuyViewModel>>(BuysCacheKey);

            if (allBuys == null)
            {
                allBuys = await buyService.AllAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan
                        .FromMinutes(BuysCacheDurationMinutes));

                memoryCache.Set(UsersCacheKey, allBuys, cacheOptions);
            }

            return View(allBuys);
        }
    }
}
