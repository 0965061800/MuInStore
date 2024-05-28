using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MuInShared.Account;
using Newtonsoft.Json;
using System.Text;

namespace MuInMVC.Pages.Account
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public LoginDto Login { get; set; }

		public string ReturnUrl { get; set; }

		Uri baseAddress = new Uri("https://localhost:7137/api");

		private readonly HttpClient _httpClient;
		public LoginModel()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}
		public void OnGet(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
		}


		[HttpPost]
		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			if (ModelState.IsValid)
			{
				NewUserDto userLogin = new NewUserDto();
				string data = JsonConvert.SerializeObject(Login);
				StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
				HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Account/login", content).Result;

				if (response.IsSuccessStatusCode)
				{
					string result = response.Content.ReadAsStringAsync().Result;
					userLogin = JsonConvert.DeserializeObject<NewUserDto>(result);
					HttpContext.Session.SetString("JWToken", userLogin.Token);
					HttpContext.Session.SetString("UserName", userLogin.UserName);
					HttpContext.Session.SetString("UserId", userLogin.UserId);
					return RedirectToPage("/");
				}
				ViewData["ErrorMessage"] = response.Content.ReadAsStringAsync().Result;
				return Page();
			}

			return Page();
		}
	}
}
