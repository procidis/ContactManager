using System;
using System.Collections.Generic;

namespace ContactManager.ModelLayer.ServiceModels
{
	public class ReportResultDto
	{
		public string UUID { get; set; }
		public List<ReportResultRowDto> Items { get; set; }
		public DateTime RequestDate { get; set; }
		public ReportStatus Status { get; set; }
	}
}
