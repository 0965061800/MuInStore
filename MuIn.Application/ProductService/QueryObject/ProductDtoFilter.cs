using MuIn.Domain.Aggregates.ProductAggregate;

namespace MuIn.Application.ProductService.QueryObject
{
    public enum ProductFilterBy
    {
        NoFilter = 0,
        ByBrand,
        ByName,
    }
    public static class ProductDtoFilter
    {
        public static IQueryable<Product> FilterProductsBy(this IQueryable<Product> products, int? catId, ProductFilterBy productFilterBy, string filterValue)
        {
            if (catId != null)
            {
                products = products.Where(p => p.Category.CatId == catId);
            }
            switch (productFilterBy)
            {
                case ProductFilterBy.NoFilter:
                    return products;
                case ProductFilterBy.ByBrand:
                    return products.Where(p => p.Brand != null && p.Brand.BrandName.Contains(filterValue));
                case ProductFilterBy.ByName:
                    return products.Where(p => p.ProductName.Contains(filterValue));
                default:
                    return products;
            }
        }
    }
}
