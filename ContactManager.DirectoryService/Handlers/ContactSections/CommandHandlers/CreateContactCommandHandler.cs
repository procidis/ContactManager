using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.DirectoryService.Commands.ContactSections;
using ContactManager.DirectoryService.Models.DB;
using ContactManager.ModelLayer;
using ContactManager.Persistence.Interfaces;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.ContactSections.CommandHandlers
{
	internal class CreateContactSectionCommandHandler : IRequestHandler<CreateContactSectionCommand, ContactSectionDto>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public CreateContactSectionCommandHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}
		public async Task<ContactSectionDto> Handle(CreateContactSectionCommand request, CancellationToken cancellationToken)
		{
			var data = mapper.Map<ContactSection>(request.Data);
			var contact = await contactRepository.GetOneAsync(request.ContactId);
			if (contact.Sections == null)
			{
				contact.Sections = new System.Collections.Generic.List<Models.DB.ContactSection>();
			}
			data.Id = Guid.NewGuid().ToString();
			contact.Sections.Add(data);
			var response = mapper.Map<ContactSectionDto>(data);
			return response;
		}
	}
}
