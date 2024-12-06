using MuIn.Domain.Aggregates.UserAggregate;
using MuInShared.User;

namespace MuInStoreAPI.Mappers
{
	public static class UserMapper
	{
		public static UserInfoDto ToUserInfoDto(this AppUser appUser)
		{
			return new UserInfoDto
			{
				FullName = appUser.FirstName + " " + appUser.LastName,
				UserID = appUser.Id,
				Email = appUser.Email,
				Address = appUser.Address,
				Phone = appUser.Phone
			};
		}

		public static UserDto ToUserDto(this AppUser appUser)
		{
			return new UserDto
			{
				UserId = appUser.Id,
				UserName = appUser.UserName,
				Phone = appUser.Phone,
				Active = appUser.Active,
				Email = appUser.Email,
				FirstName = appUser.FirstName,
			};
		}

		public static UserFullDto ToUserFullDto(this AppUser appUser)
		{
			return new UserFullDto
			{
				UserName = appUser.UserName ?? "",
				Email = appUser.Email ?? "",
				FirstName = appUser.FirstName,
				LastName = appUser.LastName,
				DOB = appUser.DOB,
				Phone = appUser.Phone,
				Address = appUser.Address,
				Avatar = appUser.Avatar,
				Active = appUser.Active,
				Orders = appUser.Orders.Select(x => x.ToOrderDto()).ToList()
			};
		}
	}
}
