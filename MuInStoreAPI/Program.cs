using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using MuIn.Application;
using MuIn.Infrastructure;
using MuInStoreAPI.Service;

namespace MuInStoreAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddApplicationServices();
			builder.Services.AddInfrastructureSerivices(builder.Configuration);

			builder.Services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type=ReferenceType.SecurityScheme,
								Id="Bearer"
							}
						},
						new string[]{}
					}
				});
			});

			builder.Services.AddScoped<ITokenService, TokenService>();

			var app = builder.Build();

			var staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(staticFilesPath),
				RequestPath = "/files"
			});

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseCors(x => x.WithOrigins("https://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin => true));

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
