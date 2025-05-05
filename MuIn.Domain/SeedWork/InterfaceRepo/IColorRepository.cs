using MuIn.Domain.Aggregates;

namespace MuIn.Domain.SeedWork.InterfaceRepo
{
	public interface IColorRepository
	{
		Task<List<Color>?> GetAllColor();
	}
}
