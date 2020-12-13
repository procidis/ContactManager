using AutoMapper;
using ContactManager.ModelLayer.ServiceModels;
using ContactManager.ReportingService.Models;

namespace ContactManager.ReportingService.Settings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ReportResult, ReportResultDto>()
				.ForMember(w => w.UUID, q => q.MapFrom(s => s.Id));
			CreateMap<ReportResultDto, ReportResult>()
				.ForMember(w => w.Id, q => q.MapFrom(s => s.UUID));
		}
	}
}
