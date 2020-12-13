using System.Threading.Tasks;
using Confluent.Kafka;
using ContactManager.CommonServices.Interfaces;
using ContactManager.DirectoryService.Commands.Reports;
using ContactManager.ModelLayer;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.DirectoryService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportsController : ControllerBase
	{
		private readonly IServiceProcessor serviceProcessor;

		public ReportsController(IServiceProcessor serviceProcessor)
		{
			this.serviceProcessor = serviceProcessor;
		}

		[HttpPost]
		public async Task<ServiceResponse<TopicPartitionOffset>> RequestReport([FromBody] RequestReportCommand request)
		{
			return await serviceProcessor.HandleAsync(request);
		}
	}
}
