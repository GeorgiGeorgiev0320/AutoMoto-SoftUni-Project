namespace CarSelling.Web.ViewModels.Car
{
    public class CarAllViewModel
    {
        public string Id { get; set; } = null!;
        public string MakeName { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public bool IsBought { get; set; }
    }
}
