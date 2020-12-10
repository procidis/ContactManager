//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using ContactManager.CommonServices.Interfaces;
//using ContactManager.ModelLayer;
//using ContactManager.ModelLayer.ServiceModels;
//using ContactManager.ReportingService.Commands;
//using Microsoft.AspNetCore.Mvc;

//namespace ContactManager.ReportingService.Controllers
//{
//	[Route("api/[controller]")]
//	[ApiController]
//	public class ReportController : ControllerBase
//	{
//		private readonly IServiceProcessor serviceProcessor;

//		public ReportController(IServiceProcessor serviceProcessor)
//		{
//			this.serviceProcessor = serviceProcessor;
//		}

//		[HttpPost]
//		public async Task<ServiceResponse<RequestReportResultDto>> RequestReport([FromBody] RequestReportCommand command)
//		{
//			return await serviceProcessor.HandleAsync(command);
//		}
//	}
//}
