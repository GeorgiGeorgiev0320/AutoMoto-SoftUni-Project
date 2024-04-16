using System.ComponentModel.DataAnnotations;


using static CarSelling.Common.EntityValidationConstants.Category;

namespace CarSelling.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required] [MaxLength(NameMaxLength)] public string Name { get; set; } = null!;

        public ICollection<Car> Cars = new List<Car>();
    }
}