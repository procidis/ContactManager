using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Commands.ContactSections
{
	public class CreateContactSectionCommand : IRequest<ContactSectionDto>, IHasData<ContactSectionDto>
	{
		public ContactSectionDto Data { get; set; }
		public string ContactId { get; set; }
	}
}
