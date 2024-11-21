using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuIn.Application.Interfaces;
using MuIn.Application.ProductService;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared;
using MuInShared.Product;

namespace MuInStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IListService<Product> _productService;

        public ProductController(IMapper mapper, IListService<Product> productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] SortFilterPageOptions sortFilterPageData)
        {
            var query = await _productService.SortFilterPage(sortFilterPageData, (int)sortFilterPageData.CatID);

            var result = await query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
            if (result == null)
            {
                return NotFound("Sorry, but there is no products in your database");
            }
            var productListResponse = new ReponseModel<List<ProductDto>>
            {
                Data = result,
                Message = "Success",
                Success = true
            };
            return Ok(productListResponse);
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
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct(RequestProductDto requestProductDto)
        {
            try
            {
                Product newProduct = _mapper.Map<Product>(requestProductDto);

                var product = await _productService.Add(newProduct, requestProductDto.ColorId);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            try
            {
                Product productToChange = _mapper.Map<Product>(updateProductDto);
                var newProduct = await _productService.Update(id, productToChange);
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

    }
}
