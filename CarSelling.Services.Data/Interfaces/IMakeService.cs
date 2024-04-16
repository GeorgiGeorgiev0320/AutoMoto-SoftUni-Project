using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Web.ViewModels.Make;

namespace CarSelling.Services.Data.Interfaces
{
    public interface IMakeService
    {
        Task<ICollection<MakeCarFormModel>> GetMakesAsync();

        Task<bool> IsValidMake(int id);
    }
}
