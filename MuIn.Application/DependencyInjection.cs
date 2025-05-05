using Microsoft.Extensions.DependencyInjection;
using MuIn.Application.BrandService;
using MuIn.Application.CategoryService;
using MuIn.Application.CheckoutService;
using MuIn.Application.ColorService;
using MuIn.Application.CommentService;
using MuIn.Application.Interfaces;
using MuIn.Application.ProductService.Concrete;
using MuIn.Application.ProductSkuService;
using System.Reflection;

namespace MuIn.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddScoped<IProductServices, ListProductService>();
			services.AddScoped<ICatService, CategoryListService>();
			services.AddScoped<IBrandServices, BrandListService>();
			services.AddScoped<IProductImageService, ProductImageServices>();
			services.AddScoped<IColorService, ColorListService>();
			services.AddScoped<ICheckoutService, CheckoutListService>();
			services.AddScoped<ICommentServices, CommentListService>();
			services.AddScoped<IProductSkuServices, ProductSkuListService>();
			return services;
		}

	}
}
