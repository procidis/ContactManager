using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.DirectoryService.Commands;
using ContactManager.DirectoryService.Models.DB;
using ContactManager.ModelLayer;
using ContactManager.Persistence.Interfaces;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.CommandHandlers
{
	internal class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactDto>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public CreateContactCommandHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}
		public async Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
		{
			var data = mapper.Map<Contact>(request.Data);
			await contactRepository.CreateAsync(data);
			var response = mapper.Map<ContactDto>(data);
			return response;
		}
	}
}
