using System;
using System.Collections.Generic;

namespace ContactManager.ModelLayer
{
	public class ContactDto
	{
		public string UUID { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Company { get; set; }
		public List<ContactSectionDto> Sections { get; set; }
	}
}
