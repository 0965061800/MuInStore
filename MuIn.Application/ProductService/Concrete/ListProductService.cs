using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuIn.Application.ProductService.QueryObject;
using MuIn.Application.QueryObject;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuIn.Infrastructure;

namespace MuIn.Application.ProductService.Concrete
{
    public class ListProductService
    {
        private readonly MuInDbContext _context;
        private readonly IMapper _mapper;
        public ListProductService(MuInDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IQueryable<Product> SortFilterPage(SortFilterPageOptions options)
        {
            var productsQuery = _context.Products.AsNoTracking().OrderProductsBy(options.OrderByOptions).FilterProductsBy(options.CatID, options.FilterBy, options.FilterValue);
            return productsQuery.Page(options.PageNum - 1, options.PageSize);
        }
    }
}
