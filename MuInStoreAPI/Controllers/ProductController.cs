using Microsoft.AspNetCore.Mvc;
using MuInShared.Product;
using MuInStoreAPI.Helpers;
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
            (string.IsNullOrEmpty(query.BrandName) || p.Brand.BrandName.Contains(query.BrandName)) &&
            (string.IsNullOrEmpty(query.CatName) || p.Category.CatName.Contains(query.CatName));

            Func<IQueryable<Product>, IOrderedQueryable<Product>> order;

            if (query.IsDescending = true)
            {
                order = q => q.OrderByDescending(d => d.ProductPrice);
            }
            else
            {
                order = q => q.OrderBy(d => d.ProductPrice);
            }

            var products = await _uow.ProductRepository.GetAll(filter, order, "Category,Feature,Brand");
            if (products == null)
            {
                return NotFound("Sorry, but there is no products in your database");
            }
            var productDtos = products.Select(x => x.ToProductDto());
            return Ok(new { Message = "Success", Count = products.Count(), Products = productDtos });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _uow.ProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound("");
            }
            await _uow.CategoryRepository.GetById(product.CategoryId);
            await _uow.BrandRepository.GetById(product.BrandId);
            await _uow.FeatureRepository.GetById(product.FeatureId);
            var productDto = product.ToProductDto();
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

                Product newProduct = requestProductDto.ToProduct();
                bool CheckCategory;
                if (newProduct.CategoryId != null)
                {
                    CheckCategory = await _uow.CategoryRepository.CheckCategoryId((int)newProduct.CategoryId);
                }
                else
                {
                    return BadRequest("Không có category này");
                }

                bool CheckBrand;
                if (newProduct.BrandId != null)
                {
                    CheckCategory = await _uow.BrandRepository.CheckBrandId((int)newProduct.BrandId);
                }
                else
                {
                    return BadRequest("Không có brand này");
                }

                bool CheckFeature;
                if (newProduct.FeatureId != null)
                {
                    CheckCategory = await _uow.FeatureRepository.CheckFeatureId((int)newProduct.FeatureId);
                }
                else
                {
                    return BadRequest("Không có thuộc tính này");
                }

                await _uow.ProductRepository.Create(newProduct);
                await _uow.Save();
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


    }
}
