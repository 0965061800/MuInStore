using Microsoft.AspNetCore.Mvc;

namespace MuInMVC.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			HttpContext.Session.Remove("JWToken");
			HttpContext.Session.Remove("UserName");
			HttpContext.Session.Remove("UserId");
			return RedirectToAction("Index", "Home");
		}
	}
}
