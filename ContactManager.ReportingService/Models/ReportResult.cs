using System;
using System.Collections.Generic;
using ContactManager.ModelLayer.ServiceModels;
using ContactManager.Persistence.Models;

namespace ContactManager.ReportingService.Models
{
	public class ReportResult : BaseModel
	{
		public List<ReportResultRowDto> Items { get; set; }
		public DateTime RequestDate { get; set; }
		public ReportStatus Status { get; set; }
	}
}
