using System;
using System.Threading;
using System.Threading.Tasks;
using ContactManager.DirectoryService.Commands;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.CommandHandlers
{
	public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
	{
		public Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
