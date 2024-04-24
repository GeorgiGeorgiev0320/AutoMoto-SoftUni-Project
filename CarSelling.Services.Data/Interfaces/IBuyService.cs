namespace CarSelling.Services.Data.Interfaces
{
    using Web.ViewModels.Buy;
    public interface IBuyService
    {
        Task<ICollection<BuyViewModel>> AllAsync();
    }
}
