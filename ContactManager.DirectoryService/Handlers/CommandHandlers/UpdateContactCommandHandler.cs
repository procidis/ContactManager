using System;
using System.Threading;
using System.Threading.Tasks;
using ContactManager.DirectoryService.Commands;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.CommandHandlers
{
	public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
	{
		public Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}