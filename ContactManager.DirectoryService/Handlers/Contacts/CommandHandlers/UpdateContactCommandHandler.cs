using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.DirectoryService.Commands.Contacts;
using ContactManager.DirectoryService.Models.DB;
using ContactManager.Persistence.Interfaces;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.Contacts.CommandHandlers
{
	internal class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public UpdateContactCommandHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
		{
			var data = mapper.Map<Contact>(request.Data);
			data.Id = request.Id;
			await contactRepository.UpdateAsync(data);
			return Unit.Value;
		}
	}
}