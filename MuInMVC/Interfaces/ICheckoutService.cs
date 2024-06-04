namespace MuInMVC.Interfaces
{
    public interface ICheckoutService
    {
        bool CheckOut(string token, string request);
    }
}
