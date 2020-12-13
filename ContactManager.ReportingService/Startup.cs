using ContactManager.Core.Implementations;
using ContactManager.Persistence.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.ReportingService
{
	public class Startup : StartupImpBase
	{
		public Startup(IConfiguration configuration) : base(configuration)
		{
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			ConfigureServicesBase(services);
			services.AddHostedService<KafkaConsumerHostedService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			base.ConfigureBase(app, env);
		}
	}
}
