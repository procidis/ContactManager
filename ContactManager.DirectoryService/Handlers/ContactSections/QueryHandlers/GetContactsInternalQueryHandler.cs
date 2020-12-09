using System.Collections.Generic;
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
	internal class GetContactSectionsInternalQueryHandler : IRequestHandler<GetContactSectionsInternalQuery, IEnumerable<ContactSectionDto>>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public GetContactSectionsInternalQueryHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}
		public async Task<IEnumerable<ContactSectionDto>> Handle(GetContactSectionsInternalQuery request, CancellationToken cancellationToken)
		{
			var contact = (await contactRepository.FilterAsync(w => w.Id == request.ContactId)).FirstOrDefault();

			if (contact == null)
			{
				throw new ServiceException("Record not found", "record_not_found");
			}
			var response = mapper.Map<List<ContactSectionDto>>(contact.Sections);
			return response;
		}
	}
}