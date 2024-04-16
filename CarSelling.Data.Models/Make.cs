using System.ComponentModel.DataAnnotations;

using static CarSelling.Common.EntityValidationConstants.Make;

namespace CarSelling.Data.Models
{
    public class Make
    {

        [Key]
        public int Id { get; set; }

        [Required][MaxLength(MakeMaxLength)] public string MakeName { get; set; } = null!;

        public ICollection<Car> Cars = new List<Car>();
    }
}