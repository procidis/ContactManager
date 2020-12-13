using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Commands.Contacts
{
	public class CreateContactCommand : IRequest<ContactDto>, IHasData<ContactDto>
	{
		public ContactDto Data { get; set; }
	}
}
