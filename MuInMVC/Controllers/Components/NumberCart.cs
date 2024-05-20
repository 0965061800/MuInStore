using Microsoft.AspNetCore.Mvc;
using MuInMVC.Extension;
using MuInShared.Cart;

namespace MuInMVC.Controllers.Components
{
    public class NumberCart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<AddToCartVM>>("GioHang");
            return View(cart);
        }
    }
}
