using MuInStoreAPI.Models;

namespace MuInStoreAPI.Service
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
