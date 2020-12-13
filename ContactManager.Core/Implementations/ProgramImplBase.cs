using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace ContactManager.Core.Implementations
{
	public class ProgramImplBase<TStartup> where TStartup : StartupImpBase
	{
		public static IHostBuilder ConfigureAppConfiguration(IHostBuilder builder) =>
				builder.ConfigureAppConfiguration(configuration =>
				{
					configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
					var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
					if (!string.IsNullOrWhiteSpace(environmentVariable))
					{
						configuration.AddJsonFile($"appsettings.{environmentVariable}.json", optional: true);
					}
				});
	}
}
