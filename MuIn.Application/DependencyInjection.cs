using Microsoft.Extensions.DependencyInjection;
using MuIn.Application.BrandService;
using MuIn.Application.CategoryService;
using MuIn.Application.ColorService;
using MuIn.Application.Interfaces;
using MuIn.Application.ProductService.Concrete;
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

			return services;
		}

	}
}
