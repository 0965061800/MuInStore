using Microsoft.AspNetCore.Mvc;

namespace MuInMVC.Controllers.Components
{
	public class LoginButton : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var UserName = HttpContext.Session.GetString("UserName");
			ViewBag.UserName = UserName;
			return View();
		}
	}
}
