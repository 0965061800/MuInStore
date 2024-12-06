using MuIn.Domain.Aggregates.UserAggregate;

namespace MuInStoreAPI.Service
{
	public interface ITokenService
	{
		string CreateToken(AppUser user);
	}
}
