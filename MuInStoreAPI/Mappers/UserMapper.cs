using MuInShared.User;
using MuInStoreAPI.Models;

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
	}
}
