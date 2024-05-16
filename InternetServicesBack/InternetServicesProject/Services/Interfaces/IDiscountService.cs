namespace InternetServicesProj.Services.Interfaces
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(IEnumerable<int> productIds);
    }
}
