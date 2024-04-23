using CarSelling.Services.Data.Interfaces;
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
    }
}
