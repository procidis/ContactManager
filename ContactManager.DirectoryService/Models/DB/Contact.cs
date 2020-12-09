using System.Collections.Generic;
using ContactManager.Persistence.Models;

namespace ContactManager.DirectoryService.Models.DB
{
	internal class Contact : BaseModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Company { get; set; }
		public List<ContactSection> Sections { get; set; }
	}
}
