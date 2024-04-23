using CarSelling.Web.ViewModels.Category.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSelling.Web.Infrastructure.Extensions
{
    public static class ViewModelExtension
    {
        public static string GetUrlInformation(this ICategoryDetailsModel model)
        {
            return model.Name.Replace(" ", "-");
        }
    }
}
