using MuInMVC.Interfaces;
using MuInMVC.Services;

namespace MuInMVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ICartService, CartService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ICheckoutService, CheckoutService>();
			builder.Services.AddScoped<IOrderService, OrderService>();
			builder.Services.AddScoped<ICommentService, CommentService>();
			builder.Services.AddScoped<IProductSkuService, ProductSkuService>();

			builder.Services.AddRazorPages();
			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
			builder.Services.AddHttpClient();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseSession();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapRazorPages();
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
