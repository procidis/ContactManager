using ContactManager.ModelLayer;

namespace ContactManager.DirectoryService.Models.DB
{
	public class ContactSection
	{
		public string Id { get; set; }
		public ContactType Type { get; set; }
		public string Detail { get; set; }
	}
}