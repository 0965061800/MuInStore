using MuIn.Infrastructure;

namespace MuIn.Application.Interfaces
{
    public abstract class AppService
    {
        protected MuInDbContext _db;
        public AppService(MuInDbContext db)
        {
            _db = db;
        }
    }
}
