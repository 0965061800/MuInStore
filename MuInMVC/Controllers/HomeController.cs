using Microsoft.AspNetCore.Mvc;
using MuInMVC.Interfaces;
using MuInMVC.Models;
using MuInShared.Helpers;
using System.Diagnostics;

namespace MuInMVC.Controllers
{
	public class HomeController : Controller
	{

		private readonly IProductService _productService;


		public HomeController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			ViewBag.UserName = HttpContext.Session.GetString("UserName");
			ProductQueryObject query = new ProductQueryObject
			{
				BestSeller = true
			};
			var productList = _productService.GetProducts(query);
			if (productList == null) return View("Error");
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
