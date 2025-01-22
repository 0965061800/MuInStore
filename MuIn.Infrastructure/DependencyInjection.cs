using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MuIn.Domain.Aggregates.UserAggregate;
using MuIn.Domain.SeedWork.InterfaceRepo;
using MuIn.Infrastructure.Repositories;

namespace MuIn.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureSerivices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<MuInDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});

			//Add Identitity Service and Configuration
			services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredLength = 12;
			}).AddEntityFrameworkStores<MuInDbContext>();

			//Add Authentication and Jwt Configuration
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateLifetime = false,
					ValidateIssuer = false,
					ValidIssuer = configuration["JWT:Issuer"],
					ValidateAudience = false,
					ValidAudience = configuration["JWT:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(
						System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
					),
					//ClockSkew = TimeSpan.Zero
				};
				options.Events = new JwtBearerEvents
				{
					OnAuthenticationFailed = context =>
					{
						Console.WriteLine("Authentication failed: " + context.Exception.Message);
						return Task.CompletedTask;
					}
				};
			});


			//services.ConfigureApplicationCookie(options =>
			//{
			//	options.Cookie.HttpOnly = true;
			//	options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
			//	options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
			//	options.LoginPath = "/Identity/Account/Login";
			//	options.LogoutPath = "/Identity/Account/Logout";
			//	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
			//});


			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IBrandRepository, BrandRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IColorRepository, ColorRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IProductSkuRepository, ProductSkuRepository>();

			return services;

		}
	}
}
