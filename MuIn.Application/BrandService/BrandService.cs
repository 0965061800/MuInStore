using MuIn.Application.Interfaces;
using MuIn.Domain.Aggregates;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Application.BrandService
{
	public class BrandService : IBrandServices
	{
		private readonly IBrandRepository _brandRepo;
		public BrandService(IBrandRepository brandRep)
		{
			_brandRepo = brandRep;
		}

		public async Task<List<Brand>?> GetAllBrand()
		{
			return await _brandRepo.GetAll();
		}
	}
}
