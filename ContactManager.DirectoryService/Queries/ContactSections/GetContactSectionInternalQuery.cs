using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Queries.ContactSections
{
	public class GetContactSectionInternalQuery : IRequest<ContactSectionDto>, IHasId
	{
		public string Id { get; set; }
	}
}
