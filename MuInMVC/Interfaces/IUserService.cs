using MuInShared.User;

namespace MuInMVC.Interfaces
{
	public interface IUserService
	{
		UserInfoDto? GetUserInfo(string token, string id);
	}
}
