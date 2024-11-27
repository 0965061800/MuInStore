using MuIn.Domain.Aggregates;

namespace MuIn.Application.Interfaces
{
	public interface IBrandServices
	{
		Task<List<Brand>?> GetAllBrand();
	}
}
