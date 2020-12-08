using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.DirectoryService.Models.DB;
using ContactManager.ModelLayer;

namespace ContactManager.DirectoryService.Settings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Contact, ContactDto>();
			CreateMap<ContactDto, Contact>();
			CreateMap<ContactSectionDto, ContactSection>();
		}
	}
}
