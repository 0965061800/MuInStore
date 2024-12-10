using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Infrastructure.Repositories
{
	public class ColorRepository : GenericRepository<Color>, IColorRepository
	{
		public ColorRepository(MuInDbContext context) : base(context)
		{
		}
		public async Task<List<Color>?> GetAllColor()
		{
			return await _context.Colors.ToListAsync();
		}
	}
}
