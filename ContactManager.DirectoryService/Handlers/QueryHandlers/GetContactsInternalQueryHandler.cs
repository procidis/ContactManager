using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContactManager.DirectoryService.Queries;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Handlers.QueryHandlers
{
	public class GetContactsInternalQueryHandler : IRequestHandler<GetContactsInternalQuery, IEnumerable<ContactDto>>
	{
		public Task<IEnumerable<ContactDto>> Handle(GetContactsInternalQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}