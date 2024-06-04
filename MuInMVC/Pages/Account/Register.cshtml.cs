using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MuInShared.Account;
using Newtonsoft.Json;
using System.Text;

namespace MuInMVC.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterDto Register { get; set; }

        public string ReturnUrl { get; set; }

        Uri baseAddress = new Uri("https://localhost:7137/api");

        private readonly HttpClient _httpClient;
        public RegisterModel()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }
        public IActionResult OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(Register);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Account/register", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var userLogin = JsonConvert.DeserializeObject<NewUserDto>(result);
                    if (userLogin != null)
                    {
                        HttpContext.Session.SetString("JWToken", userLogin.Token);
                        HttpContext.Session.SetString("UserName", userLogin.UserName);
                        HttpContext.Session.SetString("UserId", userLogin.UserId);
                    }
                    return RedirectToPage("/");
                }
                ViewData["ErrorMessage"] = response.Content.ReadAsStringAsync().Result;
                return Page();
            }

            return Page();
        }
    }
}
