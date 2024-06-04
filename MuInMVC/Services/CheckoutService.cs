using MuInMVC.Interfaces;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace MuInMVC.Services
{
    public class CheckoutService : ICheckoutService
    {
        Uri baseAddress = new Uri("https://localhost:7137/api");
        private readonly HttpClient _httpClient;
        public CheckoutService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public bool CheckOut(string token, string request)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent contentRequest = new StringContent(request, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Checkout", contentRequest).Result;
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
