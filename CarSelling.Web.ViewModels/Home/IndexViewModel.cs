using CarSelling.Services.Mapping;
namespace CarSelling.Web.ViewModels.Home
{
    using Data.Models;
    public class IndexViewModel: IMapFrom<Car>
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
