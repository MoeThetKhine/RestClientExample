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

		

	}
}
