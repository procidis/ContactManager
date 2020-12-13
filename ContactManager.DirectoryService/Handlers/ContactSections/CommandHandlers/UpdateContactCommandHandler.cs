using System.Linq;
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
	internal class UpdateContactCommandHandler : IRequestHandler<UpdateContactSectionCommand>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public UpdateContactCommandHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateContactSectionCommand request, CancellationToken cancellationToken)
		{
			var contact = (await contactRepository.FilterAsync(w => w.Sections != null && w.Sections.Any(q => q.Id == request.Id))).FirstOrDefault();

			if (contact == null)
			{
				throw new ServiceException("Record not found", "record_not_found");
			}
			var data = mapper.Map<ContactSection>(request.Data);

			var item = contact.Sections.First(w => w.Id == request.Id);
			item.Detail = data.Detail;
			item.Type = data.Type;

			await contactRepository.UpdateAsync(contact);
			return Unit.Value;
		}
	}
}