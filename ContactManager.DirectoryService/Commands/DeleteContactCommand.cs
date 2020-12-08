using System;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Commands
{
	public class DeleteContactCommand : IRequest, IHasId
	{
		public string Id { get; set; }
	}
}
