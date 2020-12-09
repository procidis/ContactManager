using System.Collections.Generic;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Queries.ContactSections
{
	public class GetContactSectionsInternalQuery : IRequest<IEnumerable<ContactSectionDto>>
	{
	}
}