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
			CreateMap<Contact, ContactDto>()
				.ForMember(w => w.UUID, q => q.MapFrom(s => s.Id));
			CreateMap<ContactDto, Contact>()
				.ForMember(w => w.Id, q => q.MapFrom(s => s.UUID));
			CreateMap<ContactSectionDto, ContactSection>();
			CreateMap<ContactSection, ContactSectionDto>();
		}
	}
}
