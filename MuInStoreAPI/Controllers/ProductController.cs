using Microsoft.AspNetCore.Mvc;
using MuInShared;
using MuInShared.Helpers;
using MuInShared.Product;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;
using System.Linq.Expressions;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IUnitOfWork _uow;
		public ProductController(IUnitOfWork uow)
		{
			_uow = uow;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct([FromQuery] ProductQueryObject query)
		{
			Expression<Func<Product, bool>> filter = p =>
			(string.IsNullOrEmpty(query.BrandAlias) || p.Brand.Alias.Contains(query.BrandAlias)) &&
			(string.IsNullOrEmpty(query.FeatureAlias) || p.Feature.Alias.Contains(query.FeatureAlias));

			Func<IQueryable<Product>, IOrderedQueryable<Product>> order = q => q.OrderBy(d => d.CreatAt);
			if (query.SortByPrice)
			{
				if (query.IsDescending == true)
				{
					order = q => q.OrderByDescending(d => d.ProductPrice);
				}
				else
				{
					order = q => q.OrderBy(d => d.ProductPrice);
				}
			}
			var products = await _uow.ProductRepository.GetAll(filter, order, "Category,Feature,Brand");

			if (products == null)
			{
				return NotFound("Sorry, but there is no products in your database");
			}
			var productDtos = products.Select(x => x.ToProductDto());
			var productListReponse = new ReponseModel<List<ProductDto>>
			{

				Data = productDtos.ToList(),
				Message = "Success",
				Success = true
			};
			return Ok(productListReponse);

		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Product>> GetById(int id)
		{
			var product = await _uow.ProductRepository.GetProductByIdAsync(id);
			if (product == null)
			{
				return NotFound("");
			}
			var productDto = product.ToProductFullDto();
			return Ok(productDto);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(RequestProductDto requestProductDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					BadRequest(ModelState);
				}
				await _uow.BeginTransactionAsync();
				try
				{
					Product newProduct = requestProductDto.ToProduct();
					if (newProduct.CategoryId != null)
					{
						bool CheckCategory = await _uow.CategoryRepository.CheckCategoryId((int)newProduct.CategoryId);
						if (!CheckCategory) return BadRequest("No Categroy Found");
					}
					if (newProduct.BrandId != null)
					{
						bool CheckBrand = await _uow.BrandRepository.CheckBrandId((int)newProduct.BrandId);
						if (!CheckBrand) return BadRequest("No Brand Found");
					}
					if (newProduct.FeatureId != null)
					{
						bool CheckFeature = await _uow.FeatureRepository.CheckFeatureId((int)newProduct.FeatureId);
						if (!CheckFeature) return BadRequest("No Feature Found");
					}

					await _uow.ProductRepository.Create(newProduct);
					await _uow.Save();

					ProductSku newProductSku = new ProductSku
					{
						ColorId = requestProductDto.ColorId,
						ProductId = newProduct.ProductId,
						UnitPrice = requestProductDto.ProductPrice,
						Sku = requestProductDto.ProductCode,
						UnitInStock = 10,
					};
					await _uow.ProductSkuRepository.Create(newProductSku);
					await _uow.Save();
					await _uow.CommitAsync();
					return Ok(newProduct);
				}
				catch (Exception ex)
				{
					await _uow.RollbackAsync();
					return StatusCode(500, ex.Message);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
		{
			try
			{
				var oldProduct = await _uow.ProductRepository.GetById(id);

				if (oldProduct == null)
				{
					return BadRequest("No Product Found");
				}
				if (!ModelState.IsValid)
				{
					BadRequest(ModelState);
				}

				if (updateProductDto.CategoryId != null)
				{
					bool CheckCategory = await _uow.CategoryRepository.CheckCategoryId((int)updateProductDto.CategoryId);
					if (!CheckCategory) return BadRequest("No Categroy Found");
				}
				if (updateProductDto.BrandId != null)
				{
					bool CheckBrand = await _uow.BrandRepository.CheckBrandId((int)updateProductDto.BrandId);
					if (!CheckBrand) return BadRequest("No Brand Found");
				}
				if (updateProductDto.FeatureId != null)
				{
					bool CheckFeature = await _uow.FeatureRepository.CheckFeatureId((int)updateProductDto.FeatureId);
					if (!CheckFeature) return BadRequest("No Feature Found");
				};

				await _uow.CategoryRepository.GetById(oldProduct.CategoryId);
				await _uow.BrandRepository.GetById(oldProduct.BrandId);
				await _uow.FeatureRepository.GetById(oldProduct.FeatureId);

				Product newProduct = updateProductDto.UpdateToProduct(oldProduct);
				await _uow.ProductRepository.Update(id, newProduct);
				await _uow.Save();
				return Ok(newProduct.ToProductDto());
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var product = await _uow.ProductRepository.GetById(id);
			var productDelete = _uow.ProductRepository.DeleteEntity(product);
			await _uow.Save();
			if (productDelete == null)
			{
				NotFound();
			}
			return NoContent();
		}

	}
}
