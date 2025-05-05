namespace MuIn.Application.Interfaces
{
	public interface IColorService
	{
		Task<List<MuIn.Domain.Aggregates.Color>?> ListAllColors();
	}
}
