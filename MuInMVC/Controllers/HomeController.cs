using Microsoft.AspNetCore.Mvc;
using MuInMVC.Models;
using MuInShared;
using MuInShared.Product;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MuInMVC.Controllers
{
	public class HomeController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;

		public HomeController()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public IActionResult Index()
		{
			ViewBag.UserName = HttpContext.Session.GetString("UserName");
			ReponseModel<List<ProductDto>> productList = new();
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Product?bestSeller=true").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				productList = JsonConvert.DeserializeObject<ReponseModel<List<ProductDto>>>(data);
			}
			ViewData["BestSellerProducts"] = productList.Data.Take(3).ToList();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
