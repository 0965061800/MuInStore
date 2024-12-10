using MuIn.Domain.Aggregates;

namespace MuIn.Application.Interfaces
{
	public interface IColorService
	{
		Task<List<Color>?> ListAllColors();
	}
}
