using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.DirectoryService.Models.DB;
using ContactManager.DirectoryService.Queries;
using ContactManager.ModelLayer;
using ContactManager.Persistence.Interfaces;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.QueryHandlers
{
	internal class GetContactsInternalQueryHandler : IRequestHandler<GetContactsInternalQuery, IEnumerable<ContactDto>>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public GetContactsInternalQueryHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}
		public async Task<IEnumerable<ContactDto>> Handle(GetContactsInternalQuery request, CancellationToken cancellationToken)
		{
			var result = await contactRepository.GetAllAsync();
			var response = mapper.Map<List<ContactDto>>(result);
			return response;
		}
	}
}