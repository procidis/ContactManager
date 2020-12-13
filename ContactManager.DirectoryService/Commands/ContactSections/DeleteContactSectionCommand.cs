using ContactManager.CommonServices.Interfaces;
using MediatR;

namespace ContactManager.DirectoryService.Commands.ContactSections
{
	public class DeleteContactSectionCommand : IRequest, IHasId
	{
		public string Id { get; set; }
	}
}
