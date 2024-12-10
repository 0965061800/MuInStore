using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		private readonly IListService<Product> _productService;
		private readonly IProductImageService _productImageService;
		public ProductController(IMapper mapper, IListService<Product> productService, IProductImageService productImageService)
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
				SortFilterPageOptions sortFilterPageData = _mapper.Map<SortFilterPageOptions>(sortFilterPageRequest);
				var query = await _productService.SortFilterPage(sortFilterPageData);

				var result = await query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
				if (result == null)
				{
					return NotFound("Sorry, but there is no products in your database");
				}
				SortFilterPageOptionResponse sortFilterPageOptionResponse = _mapper.Map<SortFilterPageOptionResponse>(sortFilterPageData);
				var productCombineResult = new ProductListCombine(sortFilterPageOptionResponse, result);
				return Ok(productCombineResult);
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
			var productFullDto = await product.ProjectTo<ProductFullDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
			return Ok(productFullDto);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct([FromForm] RequestProductDto requestProductDto, [FromForm] IFormFile productImage, [FromForm] int ColorId)
		{
			using var memoryStream = new MemoryStream();
			await productImage.CopyToAsync(memoryStream);
			var imageName = await _productImageService.UploadImageAsync(memoryStream.ToArray(), productImage.FileName);
			try
			{
				Product newProduct = _mapper.Map<Product>(requestProductDto);
				newProduct.ProductImage = imageName ?? "";
				var product = await _productService.Add(newProduct, ColorId);
				ProductDto productResponse = _mapper.Map<ProductDto>(product);
				return Ok(productResponse);
			}
			catch (Exception ex)
			{
				_productImageService.DeleteImage(imageName);
				return StatusCode(500, ex.Message);
			}
		}
		[HttpPut("{id:int}")]
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
