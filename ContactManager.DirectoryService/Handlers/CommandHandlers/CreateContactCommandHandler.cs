using System;
using System.Threading;
using System.Threading.Tasks;
using ContactManager.DirectoryService.Commands;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.CommandHandlers
{
	public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactDto>
	{
		public Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
