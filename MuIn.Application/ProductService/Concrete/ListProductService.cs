using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MuIn.Application.Dtos;
using MuIn.Application.Interfaces;
using MuIn.Application.ProductService.QueryObject;
using MuIn.Application.QueryObject;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuIn.Domain.SeedWork.InterfaceRepo;
using MuInShared.Cart;
using MuInShared.Product;

namespace MuIn.Application.ProductService.Concrete
{
	public class ListProductService : IProductServices
	{
		private ICategoryRepository _catRepo;
		private IProductRepository _productRepo;
		private IBrandRepository _brandRepo;
		private readonly IMapper _mapper;
		public ListProductService(ICategoryRepository catRepository, IBrandRepository brandRepository, IProductRepository productRepo, IMapper mapper)
		{
			_catRepo = catRepository;
			_productRepo = productRepo;
			_brandRepo = brandRepository;
			_mapper = mapper;
		}

		public async Task<ProductListCombine> SortFilterPage(SortFilterPageOptionRequest sortFilterPageRequest)
		{
			SortFilterPageOptions options = _mapper.Map<SortFilterPageOptions>(sortFilterPageRequest);
			List<int> catIdList = await _catRepo.FindCatIdAndAllSubCatId(options.CatID ?? 0);
			var productsQuery = _productRepo.GetAllProductAsQueryable()
				.AsNoTracking()
				.OrderProductsBy(options.OrderByOptions)
				.FilterProductsBy(catIdList, options.FilterBy, options.FilterValue);
			options.SetupRestOfDto(productsQuery);

			productsQuery.Page(options.PageNum - 1, options.PageSize);

			var result = await productsQuery.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();

			SortFilterPageOptionResponse sortFilterPageOptionResponse = _mapper.Map<SortFilterPageOptionResponse>(options);

			var productCombineResult = new ProductListCombine(sortFilterPageOptionResponse, result);

			return productCombineResult;
		}

		public async Task<ProductFullDto?> GetById(int id)
		{
			var product = _productRepo.GetAllProductAsQueryable().AsNoTracking().Where(x => x.ProductId == id);
			return await product.ProjectTo<ProductFullDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
		}

		public Task<Product?> Add(Product item)
		{
			throw new NotImplementedException();
		}

		public async Task<ProductDto?> Add(RequestProductDto request, int colorID, string imageName)
		{

			Product newProduct = _mapper.Map<Product>(request);
			newProduct.ProductImage = imageName ?? "";

			if (newProduct.CategoryId is not null)
			{
				bool catExist = await _catRepo.CheckCatExist((int)newProduct.CategoryId);
				if (!catExist) throw new Exception("Category does not exist");
			}
			if (newProduct.BrandId != null)
			{
				bool brandExist = await _brandRepo.CheckBrandExist((int)newProduct.BrandId);
				if (!brandExist) throw new Exception("Brand does not exist");
			}

			ProductSku newProductSku = new ProductSku
			{
				ColorId = colorID,
				ProductId = newProduct.ProductId,
				UnitPrice = newProduct.ProductPrice,
				Sku = newProduct.ProductCode,
				UnitInStock = 10,
				ImageName = newProduct.ImageName,
				skuImage = newProduct.ProductImage
			};

			newProduct.ProductSkus = new();
			newProduct.ProductSkus.Add(newProductSku);

			await _productRepo.CreateAsync(newProduct);
			await _productRepo.SaveChange();
			return _mapper.Map<ProductDto>(newProduct);
		}

		public async Task<Product?> Update(int id, Product item)
		{
			bool checkProduct = _productRepo.CheckProductExist(item.ProductId);

			if (checkProduct == null)
			{
				throw new Exception("No product found");
			}
			if (item.CategoryId is not null)
			{
				bool catExist = await _catRepo.CheckCatExist((int)item.CategoryId);
				if (!catExist) throw new Exception("Category does not exist");
			}
			if (item.BrandId != null)
			{
				bool brandExist = await _brandRepo.CheckBrandExist((int)item.BrandId);
				if (!brandExist) throw new Exception("Brand does not exist");
			}
			item.ProductId = id;

			await _productRepo.UpdateAsync(item);
			await _productRepo.SaveChange();
			return item;
		}

		public async Task<Product?> Delete(int id)
		{
			bool checkProduct = _productRepo.CheckProductExist(id);
			if (!checkProduct) throw new Exception("Can not find this product");
			var product = await _productRepo.Delete(id);
			if (product is not null) await _productRepo.SaveChange();
			return product;
		}

		public async Task<List<CartItemReponse>> GetCartItemInfo(List<AddToCartVM> cartItems)
		{
			List<CartItemReponse> cartItemReponse = new List<CartItemReponse>();
			var productQuery = _productRepo.GetAllProductAsQueryable();

			foreach (var item in cartItems)
			{
				var newCartItemReponse = await productQuery.Where(x => x.ProductId == item.ProductId).Select(x => new CartItemReponse
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					//ProductImage = productSku.Images == null ? productSku.Images.FirstOrDefault().ImageUrl : "",
					ProductSkuId = x.ProductSkus.Where(x => x.ColorId == item.ColorId).FirstOrDefault().ProductSkuId,
					UnitPrice = x.ProductSkus.Where(x => x.ColorId == item.ColorId).FirstOrDefault().UnitPrice,
					Amount = item.Quantity,
					ColorId = item.ColorId,
					ColorName = x.ProductSkus.Where(x => x.ColorId == item.ColorId).FirstOrDefault().Color.ColorName
				}).FirstOrDefaultAsync();
				cartItemReponse.Add(newCartItemReponse);
			}
			return cartItemReponse;
		}
	}
}
