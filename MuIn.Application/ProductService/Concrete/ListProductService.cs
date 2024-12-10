using Microsoft.EntityFrameworkCore;
using MuIn.Application.Interfaces;
using MuIn.Application.ProductService.QueryObject;
using MuIn.Application.QueryObject;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuIn.Domain.SeedWork.InterfaceRepo;
using MuIn.Infrastructure;
using MuInShared.Product;

namespace MuIn.Application.ProductService.Concrete
{
	public class ListProductService : AppService, IListService<Product>
	{
		private ICategoryRepository _catRepo;
		private IProductRepository _productRepo;
		private IBrandRepository _brandRepo;
		public ListProductService(MuInDbContext context, ICategoryRepository catRepository, IBrandRepository brandRepository, IProductRepository productRepo) : base(context)
		{
			_catRepo = catRepository;
			_productRepo = productRepo;
			_brandRepo = brandRepository;
		}

		public async Task<IQueryable<Product>> SortFilterPage(SortFilterPageOptions options)
		{
			List<int> catIdList = await _catRepo.FindCatIdAndAllSubCatId(options.CatID ?? 0);
			var productsQuery = _db.Products
				.AsNoTracking()
				.OrderProductsBy(options.OrderByOptions)
				.FilterProductsBy(catIdList, options.FilterBy, options.FilterValue);
			options.SetupRestOfDto(productsQuery);
			return productsQuery.Page(options.PageNum - 1, options.PageSize);
		}

		public async Task<IQueryable<Product?>> GetById(int id)
		{
			var product = _db.Products.AsNoTracking().Where(x => x.ProductId == id);
			return product;
		}

		public Task<Product?> Add(Product item)
		{
			throw new NotImplementedException();
		}

		public async Task<Product?> Add(Product item, int colorID)
		{
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

			ProductSku newProductSku = new ProductSku
			{
				ColorId = colorID,
				ProductId = item.ProductId,
				UnitPrice = item.ProductPrice,
				Sku = item.ProductCode,
				UnitInStock = 10,
				ImageName = item.ImageName,
				skuImage = item.ProductImage
			};

			item.ProductSkus = new();
			item.ProductSkus.Add(newProductSku);

			await _productRepo.CreateAsync(item);
			await _productRepo.SaveChange();
			return item;
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

	}
}
