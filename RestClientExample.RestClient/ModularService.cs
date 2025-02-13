using RestClientExample.RestClient.Features.Blog;

namespace RestClientExample.RestClient;

public static class ModularService
{

	#region AddBusinessLogicServices

	public static IServiceCollection AddBusinessLogicServices(this  IServiceCollection services)
	{
		services.AddScoped<BL_Blog>();
		return services;
	}

	#endregion

	#region AddDataAccessServices

	public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
	{
		services.AddScoped<DA_Blog>();
		return services;
	}

	#endregion

	#region AddCustomServices

	public static IServiceCollection AddCustomServices(this IServiceCollection services, WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext(opt =>
		{
			opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
		}, ServiceLifetime.Transient);
		return services;
	}

	#endregion

	#region AddService

	public static IServiceCollection AddService(this IServiceCollection services, WebApplicationBuilder builder)
	{
		services.AddBusinessLogicServices();
		services.AddDataAccessServices();
		services.AddCustomServices(builder);
		return services;
	}

	#endregion

}
