using Microsoft.AspNetCore.Mvc;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FeatureController : ControllerBase
	{
		private readonly IUnitOfWork _uow;
		public FeatureController(IUnitOfWork uow)
		{
			_uow = uow;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Feature>>> GetAllFeature()
		{
			var features = await _uow.FeatureRepository.GetAll();
			if (features == null)
			{
				return NotFound("There is no category in your database");
			}
			var featureDtos = features.Select(x => x.ToFeatureDto());
			return Ok(features);
		}

	}
}
