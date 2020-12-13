namespace ContactManager.ModelLayer.ServiceModels
{
	public class ReportResultRowDto
	{
		public ContactSectionDto LocationInfo { get; set; }
		public long ContactCount { get; set; }
		public long PhoneNumberCount { get; set; }
	}
}
