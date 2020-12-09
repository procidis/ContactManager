using System.Reflection;
using AutoMapper;
using ContactManager.CommonServices.Interfaces;
using ContactManager.CommonServices.Services;
using ContactManager.DirectoryService.Filters;
using ContactManager.DirectoryService.Pipeline;
using ContactManager.Persistence.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContactManager.DirectoryService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers(configure =>
			{
				configure.Filters.AddService<RequestExceptionFilter>();
			}).AddNewtonsoftJson(options => options.UseMemberCasing());

			services.AddSwaggerGen();

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

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
