using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuInShared.Cart;
using MuInStoreAPI.Extensions;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CheckoutController : ControllerBase
	{
		private readonly IUnitOfWork _uow;
		private readonly UserManager<AppUser> _userManager;
		public CheckoutController(IUnitOfWork uow, UserManager<AppUser> userManager)
		{
			_uow = uow;
			_userManager = userManager;
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Checkout([FromBody] List<CartItemReponse> cart)
		{
			try
			{
				var username = User.GetUserName();
				var appUser = await _userManager.FindByNameAsync(username);
				await _uow.BeginTransactionAsync();
				try
				{

					Payment newPayment = new Payment
					{
						Amount = Convert.ToInt32(cart.Sum(x => x.TotalMoney)),
						PayStatusId = 1
					};
					await _uow.PaymentRepository.Create(newPayment);
					await _uow.Save();

					Order newOrder = new Order
					{
						SumTotal = Convert.ToInt32(cart.Sum(x => x.TotalMoney)),
						Address = appUser.Address,
						PaymentId = newPayment.PaymentId,
						AppUserId = appUser.Id,
					};
					await _uow.OrderRepository.Create(newOrder);
					await _uow.Save();

					foreach (var item in cart)
					{
						OrderDetail orderDetail = new OrderDetail
						{
							OrderId = newOrder.OrderId,
							ProductSkuId = item.ProductSkuId,
							Quantity = item.Amount,
							Total = (decimal)item.TotalMoney,
						};
						await _uow.OrderDetailRepository.Create(orderDetail);
					}
					await _uow.Save();
					await _uow.CommitAsync();
					return Ok(newOrder.ToOrderDto());
				}
				catch (Exception ex)
				{
					await _uow.RollbackAsync();
					return StatusCode(500, ex.Message);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

		}
	}
}
