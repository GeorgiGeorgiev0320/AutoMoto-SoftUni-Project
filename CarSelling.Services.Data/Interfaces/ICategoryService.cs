using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Web.ViewModels.Category;

namespace CarSelling.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryCarFormModel>> GetCategoriesAsync();

        Task<ICollection<AllCategoriesViewModel>> GetAllCategoriesToListAsync();

        Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id);

        Task<bool> IsValidCategory(int id);

        Task<ICollection<string>> AllCategoryNamesAsync();
    }
}
