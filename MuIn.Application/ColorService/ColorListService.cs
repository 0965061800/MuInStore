using MuIn.Application.Interfaces;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Application.ColorService
{
	public class ColorListService : IColorService
	{
		private readonly IColorRepository _colorRepo;
		public ColorListService(IColorRepository colorRepo)
		{
			_colorRepo = colorRepo;
		}
		public async Task<List<MuIn.Domain.Aggregates.Color>?> ListAllColors()
		{
			return await _colorRepo.GetAllColor();
		}
	}
}
