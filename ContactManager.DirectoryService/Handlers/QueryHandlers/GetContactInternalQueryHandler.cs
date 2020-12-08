using System;
using System.Threading;
using System.Threading.Tasks;
using ContactManager.DirectoryService.Queries;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.QueryHandlers
{
	public class GetContactInternalQueryHandler : IRequestHandler<GetContactInternalQuery, ContactDto>
	{
		public Task<ContactDto> Handle(GetContactInternalQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}