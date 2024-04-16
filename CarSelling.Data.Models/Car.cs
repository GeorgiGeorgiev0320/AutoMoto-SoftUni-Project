using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static CarSelling.Common.EntityValidationConstants.Car;

namespace CarSelling.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))] 
        public Make Make { get; set; } = null!;

        [Required] [MaxLength(ModelMaxLength)] public string Model { get; set; } = null!;

        [Required][MaxLength(DescriptionMaxLength)] public string Description { get; set; } = null!;

        [Required] public int HorsePower { get; set; }

        [Required] public int Mileage { get; set; }

         public DateTime Year { get; set; } 

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [Required]
        public Guid SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public Seller Seller { get; set; } = null!;

        public Guid? BuyerId { get; set; }

        public ApplicationUser? Buyer { get; set; }
    }
}