using RestClientExample.RestClient.Features.Blog;

namespace RestClientExample.RestClient
{
	public static class ModularService
	{
		
		public static IServiceCollection AddBusinessLogicServices(this  IServiceCollection services)
		{
			services.AddScoped<BL_Blog>();
			return services;
		}

		public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
		{
			services.AddScoped<DA_Blog>();
			return services;
		}

		public static IServiceCollection AddCustomServices(this IServiceCollection services, WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext(opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
			}, ServiceLifetime.Transient);
			return services;
		}

		
	}
}
