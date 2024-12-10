using MuIn.Application.Interfaces;
using MuIn.Domain.Aggregates;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Application.ColorService
{
	public class ColorService : IColorService
	{
		private readonly IColorRepository _colorRepo;
		public ColorService(IColorRepository colorRepo)
		{
			_colorRepo = colorRepo;
		}
		public async Task<List<Color>?> ListAllColors()
		{
			return await _colorRepo.GetAllColor();
		}
	}
}
