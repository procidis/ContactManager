using ContactManager.Persistence.Implementations;
using ContactManager.Persistence.Interfaces;
using ContactManager.Persistence.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Persistence.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddGenericDb(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<DBSettings>(configuration.GetSection(nameof(DBSettings)));
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			return services;
		}
	}
}
