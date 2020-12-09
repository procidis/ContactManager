using System;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Commands.ContactSections
{
	public class UpdateContactSectionCommand : IRequest, IHasData<ContactSectionDto>, IHasId
	{
		public ContactSectionDto Data { get; set; }
		public string ContactId { get; set; }
		public string Id { get; set; }
	}
}
