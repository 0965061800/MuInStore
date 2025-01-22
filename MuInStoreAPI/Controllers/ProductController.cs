using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuIn.Application.Dtos;
using MuIn.Application.Interfaces;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.Product;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IProductServices _productService;
		private readonly IProductImageService _productImageService;
		public ProductController(IMapper mapper, IProductServices productService, IProductImageService productImageService)
		{
			_mapper = mapper;
			_productService = productService;
			_productImageService = productImageService;
		}

		[HttpGet]
		public async Task<ActionResult> GetProducts([FromQuery] SortFilterPageOptionRequest sortFilterPageRequest)
		{
			try
			{
				var result = await _productService.SortFilterPage(sortFilterPageRequest);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ProductFullDto>> GetById(int id)
		{
			var product = await _productService.GetById(id);
			if (product == null)
			{
				return NotFound("");
			}
			return Ok(product);
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CreateProduct([FromForm] RequestProductDto requestProductDto, [FromForm] IFormFile productImage, [FromForm] int ColorId)
		{
			using var memoryStream = new MemoryStream();
			await productImage.CopyToAsync(memoryStream);
			var imageName = await _productImageService.UploadImageAsync(memoryStream.ToArray(), productImage.FileName);
			try
			{
				var product = await _productService.Add(requestProductDto, ColorId, imageName ?? "");
				return Ok(product);
			}
			catch (Exception ex)
			{
				await _productImageService.DeleteImage(imageName);
				return StatusCode(500, ex.Message);
			}
		}
		[HttpPut("{id:int}")]
		[Authorize]
		public async Task<IActionResult> UpdateProduct(int id, [FromForm] RequestProductDto requestProductDto)
		{

			try
			{
				Product productToChange = _mapper.Map<Product>(requestProductDto);
				var newProduct = await _productService.Update(id, productToChange);
				if (newProduct is not null)
				{
					var updatedProduct = await _productService.Update(id, newProduct);
					return Ok(updatedProduct);
				}
				return Ok(newProduct);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		[HttpDelete("{id:int}")]
		[Authorize]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			try
			{
				var product = await _productService.Delete(id);
				if (product is null)
				{
					return NotFound();
				}
				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpPut]
		[Route("productImage/{id:int}")]
		public async Task<IActionResult> UpdateProductImage(int id, [FromForm] IFormFile? productImage)
		{
			try
			{
				if (productImage is null)
				{
					await _productImageService.UpdateImageAsync(id, null, null);
				}
				else
				{
					using var memoryStream = new MemoryStream();
					await productImage.CopyToAsync(memoryStream);

					await _productImageService.UpdateImageAsync(id, memoryStream.ToArray(), productImage.FileName);
				}
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

	}
}
