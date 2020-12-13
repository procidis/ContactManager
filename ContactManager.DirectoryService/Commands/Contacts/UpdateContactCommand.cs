using System;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Commands.Contacts
{
	public class UpdateContactCommand : IRequest, IHasData<ContactDto>, IHasId
	{
		public ContactDto Data { get; set; }
		public string Id { get; set; }
	}
}
