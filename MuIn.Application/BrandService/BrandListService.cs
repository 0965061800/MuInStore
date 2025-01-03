using MuIn.Application.Interfaces;
using MuIn.Domain.Aggregates;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Application.BrandService
{
	public class BrandListService : IBrandServices
	{
		private readonly IBrandRepository _brandRepo;
		public BrandListService(IBrandRepository brandRep)
		{
			_brandRepo = brandRep;
		}

		public async Task<List<Brand>?> GetAllBrand()
		{
			return await _brandRepo.GetAll();
		}
	}
}
