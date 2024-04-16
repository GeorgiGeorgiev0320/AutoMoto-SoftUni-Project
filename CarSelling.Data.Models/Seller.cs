using System.ComponentModel.DataAnnotations;

using static CarSelling.Common.EntityValidationConstants.Seller;

namespace CarSelling.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required] 
        [MaxLength(PhoneMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public ICollection<Car> CarsForSelling { get; set; } = new List<Car>();
    }
}