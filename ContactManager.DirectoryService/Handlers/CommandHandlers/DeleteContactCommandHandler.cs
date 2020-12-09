using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.DirectoryService.Commands;
using ContactManager.DirectoryService.Models.DB;
using ContactManager.Persistence.Interfaces;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.CommandHandlers
{
	internal class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
	{
		private readonly IGenericRepository<Contact> contactRepository;

		public DeleteContactCommandHandler(IGenericRepository<Contact> contactRepository)
		{
			this.contactRepository = contactRepository;
		}
		public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
		{
			await contactRepository.RemoveAsync(request.Id);
			return Unit.Value;
		}
	}
}
