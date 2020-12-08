using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Persistence.Models;

namespace ContactManager.DirectoryService.Models.DB
{
	internal class Contact : BaseModel
	{
		public string UUID { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Company { get; set; }
		public List<ContactSection> Sections { get; set; }
	}
}
