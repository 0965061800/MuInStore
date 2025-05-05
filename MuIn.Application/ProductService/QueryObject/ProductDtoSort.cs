using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.Product;

namespace MuIn.Application.ProductService.QueryObject
{
    public static class ProductDtoSort
    {
        public static IQueryable<Product> OrderProductsBy(this IQueryable<Product> products, OrderProductByOptions orderProductByOptions)
        {
            switch (orderProductByOptions)
            {
                case OrderProductByOptions.SimpleOrder:
                    return products.OrderByDescending(x => x.ProductId);
                case OrderProductByOptions.ByVotes:
                    return products.OrderByDescending(x => x.Comments.Any() ? x.Comments.Average(x => x.Rate) : 0);
                case OrderProductByOptions.ByPriceLowestFirst:
                    return products.OrderBy(x => x.ProductPrice);
                case OrderProductByOptions.ByPriceHighestFirst:
                    return products.OrderByDescending(x => x.ProductPrice);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderProductByOptions), orderProductByOptions, null);
            }
        }
    }
}
