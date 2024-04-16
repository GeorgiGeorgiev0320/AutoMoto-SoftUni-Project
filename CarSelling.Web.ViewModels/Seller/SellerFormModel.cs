using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarSelling.Common.EntityValidationConstants.Seller;

namespace CarSelling.Web.ViewModels.Seller
{
    public class SellerFormModel
    {
        [Required]
        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
        [Phone]
        [Display(Name = "Your number")]
        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
