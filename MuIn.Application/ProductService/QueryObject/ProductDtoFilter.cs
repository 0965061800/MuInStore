using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.Product;

namespace MuIn.Application.ProductService.QueryObject
{
	public static class ProductDtoFilter
	{
		public static IQueryable<Product> FilterProductsBy(this IQueryable<Product> products, List<int> catIdList, ProductFilterBy productFilterBy, string filterValue)
		{
			if (catIdList.Count > 0)
			{
				products = products.Where(x => catIdList.Contains((int)x.CategoryId));
			}
			switch (productFilterBy)
			{
				case ProductFilterBy.NoFilter:
					return products;
				case ProductFilterBy.ByBrand:
					return products.Where(p => p.Brand != null && p.BrandId == int.Parse(filterValue));
				case ProductFilterBy.ByName:
					return products.Where(p => p.ProductName.Contains(filterValue));
				default:
					return products;
			}
		}
	}
}
