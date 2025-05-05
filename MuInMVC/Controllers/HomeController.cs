using Microsoft.AspNetCore.Mvc;
using MuInMVC.Interfaces;
using MuInMVC.Models;
using MuInShared.Product;
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
			SortFilterPageOptionRequest query = new();
			query.FilterBy = ProductFilterBy.NoFilter;
			query.OrderByOptions = OrderProductByOptions.SimpleOrder;
			query.PageNum = 1;
			query.PageSize = 3;
			var productListCombine = _productService.GetProducts(query);
			if (productListCombine == null) return View("Error");
			ViewData["BestSellerProducts"] = productListCombine.ProductList.Take(3).ToList();
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
