using CarSelling.Services.Data.Interfaces;
using CarSelling.Web.Infrastructure.Extensions;
using CarSelling.Web.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSelling.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            ICollection<AllCategoriesViewModel> viewModel = await categoryService.GetAllCategoriesToListAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            bool categoryExists = await this.categoryService.IsValidCategory(id);
            if (!categoryExists)
            {
                return this.NotFound();
            }

            CategoryDetailsViewModel viewModel =
                await this.categoryService.GetDetailsByIdAsync(id);
            if (viewModel.GetUrlInformation() != information)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
