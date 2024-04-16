using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSelling.Web.ViewModels.Category;
using CarSelling.Web.ViewModels.Make;

using static CarSelling.Common.EntityValidationConstants.Car;

namespace CarSelling.Web.ViewModels.Car
{
    public class CarFormModel
    {
        [Required]
        [Display(Name = "Make")]
        public int MakeId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public ICollection<MakeCarFormModel> Makes { get; set; } = new List<MakeCarFormModel>();

        public ICollection<CategoryCarFormModel> Categories { get; set; } = new List<CategoryCarFormModel>();

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; set; } = null!;


        [Range(typeof(int), CarMileageMin, CarMileageMax)]
        public int Mileage { get; set; }


        [Range(typeof(int), CarPowerMin, CarPowerMax)]
        public int HorsePower { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength, MinimumLength = 10, ErrorMessage = "Error, your image url is not valid!")]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; }= null!;

        [Range(typeof(decimal), CarPriceMin, CarPriceMax)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Date of production")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; } = DateTime.UtcNow;
    }
}
