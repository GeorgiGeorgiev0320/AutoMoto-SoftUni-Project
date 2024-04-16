using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CarSelling.Data.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {

        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
        public ICollection<Car> BoughtCars { get; set; } = new List<Car>();
    }


}
