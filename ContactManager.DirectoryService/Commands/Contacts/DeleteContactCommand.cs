using System;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Commands.Contacts
{
	public class DeleteContactCommand : IRequest, IHasId
	{
		public string Id { get; set; }
	}
}
