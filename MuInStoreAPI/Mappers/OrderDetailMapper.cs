using MuInShared.Order;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
	public static class OrderDetailMapper
	{
		public static OrderDetailDto ToOrderDetailDto(this OrderDetail orderDetail)
		{
			return new OrderDetailDto()
			{
				OrderDetailId = orderDetail.OrderId,
				OrderId = orderDetail.OrderId,
				ProductName = orderDetail.ProductName,
				ProductId = orderDetail.ProductId,
				UnitPrice = orderDetail.UnitPrice,
				ColorName = orderDetail.ColorName,
				Quantity = orderDetail.Quantity,
				SaleRate = orderDetail.SaleRate,
				Total = orderDetail.Total,
			};
		}
	}
}
