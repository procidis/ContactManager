using System.Collections.Generic;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Queries.Contacts
{
	public class GetContactsInternalQuery : IRequest<IEnumerable<ContactDto>>
	{
	}
}