using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.DirectoryService.Models.DB;
using ContactManager.DirectoryService.Queries.ContactSections;
using ContactManager.ModelLayer;
using ContactManager.Persistence.Interfaces;
using MediatR;

namespace ContactSectionManager.DirectoryService.Handlers.ContactSections.QueryHandlers
{
	internal class GetContactSectionInternalQueryHandler : IRequestHandler<GetContactSectionInternalQuery, ContactSectionDto>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public GetContactSectionInternalQueryHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}

		public async Task<ContactSectionDto> Handle(GetContactSectionInternalQuery request, CancellationToken cancellationToken)
		{
			var contact = (await contactRepository.FilterAsync(w => w.Sections != null && w.Sections.Any(q => q.Id == request.Id))).FirstOrDefault();

			if (contact == null)
			{
				throw new ServiceException("Record not found", "record_not_found");
			}

			var item = contact.Sections.First(w => w.Id == request.Id);

			var response = mapper.Map<ContactSectionDto>(item);
			return response;
		}
	}
}