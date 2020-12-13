using ContactManager.Core.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContactManager.ReportingService
{
	public class Program : ProgramImplBase<Startup>
	{
		public static void Main(string[] args)
		{
			ConfigureAppConfiguration(CreateHostBuilder(args))
				.Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
