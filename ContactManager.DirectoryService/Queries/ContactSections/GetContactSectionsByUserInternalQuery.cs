using System.Collections.Generic;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Queries.ContactSections
{
	public class GetContactSectionsByUserInternalQuery : IRequest<IEnumerable<ContactSectionDto>>
	{
		public string UserId { get; set; }
	}
}
