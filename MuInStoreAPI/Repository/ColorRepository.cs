using MuInStoreAPI.Data;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
	public class ColorRepository : GenericRepository<Color>, IColorRepository
	{
		private readonly ApplicationDbContext _context;
		public ColorRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}
	}
}
