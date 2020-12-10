using System.Reflection;
using AutoMapper;
using ContactManager.CommonServices.Interfaces;
using ContactManager.CommonServices.Services;
using ContactManager.Core.Filters;
using ContactManager.Core.Pipeline;
using ContactManager.Persistence.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContactManager.Core.Implementations
{
	public abstract class StartupImpBase
	{
		protected StartupImpBase(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected IConfiguration Configuration { get; }

		protected virtual void ConfigureServicesAddControllers(IServiceCollection services)
		{
			services.AddControllers(configure =>
				{
					configure.Filters.AddService<RequestExceptionFilter>();
				}).AddNewtonsoftJson(options => options.UseMemberCasing());
		}

		protected virtual void ConfigureServicesAddSwagger(IServiceCollection services)
		{
			services.AddSwaggerGen();
		}

		protected virtual void ConfigureServicesBase(IServiceCollection services)
		{
			ConfigureServicesAddControllers(services);
			ConfigureServicesAddSwagger(services);

			var assembly = Assembly.GetEntryAssembly();
			services.AddValidatorsFromAssembly(assembly);
			services.AddMediatR(assembly);
			services.AddAutoMapper(assembly);

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			services.AddGenericDb(Configuration);

			services.AddScoped<RequestExceptionFilter>();
			services.AddScoped<IServiceProcessor, ServiceProcessor>();
			services.AddScoped<ITicketService, TicketService>();
		}

		protected virtual void ConfigureBase(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseRouting();

			//app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
