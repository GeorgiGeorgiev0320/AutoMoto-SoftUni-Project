using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Web.ViewModels.User;

namespace CarSelling.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> FindNameByEmailAsync(string email);

        Task<ICollection<UserViewModel>> AllUsersAsync();
    }
}
