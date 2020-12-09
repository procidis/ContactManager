using System;
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
	internal class GetContactInternalQueryHandler : IRequestHandler<GetContactInternalQuery, ContactDto>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public GetContactInternalQueryHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}

		public async Task<ContactDto> Handle(GetContactInternalQuery request, CancellationToken cancellationToken)
		{
			var result = await contactRepository.GetOneAsync(request.Id);
			var response = mapper.Map<ContactDto>(result);
			return response;
		}
	}
}