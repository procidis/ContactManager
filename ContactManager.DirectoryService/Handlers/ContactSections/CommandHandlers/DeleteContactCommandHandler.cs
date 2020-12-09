using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.DirectoryService.Commands.ContactSections;
using ContactManager.DirectoryService.Models.DB;
using ContactManager.Persistence.Interfaces;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.ContactSections.CommandHandlers
{
	internal class DeleteContactCommandHandler : IRequestHandler<DeleteContactSectionCommand>
	{
		private readonly IGenericRepository<Contact> contactRepository;
		private readonly IMapper mapper;

		public DeleteContactCommandHandler(IGenericRepository<Contact> contactRepository, IMapper mapper)
		{
			this.contactRepository = contactRepository;
			this.mapper = mapper;
		}
		public async Task<Unit> Handle(DeleteContactSectionCommand request, CancellationToken cancellationToken)
		{
			var contact = (await contactRepository.FilterAsync(w => w.Sections != null && w.Sections.Any(q => q.Id == request.Id))).FirstOrDefault();
			contact.Sections?.RemoveAll(w => w.Id == request.Id);

			await contactRepository.UpdateAsync(contact);
			return Unit.Value;
		}
	}
}
