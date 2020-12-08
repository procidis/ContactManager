﻿using System;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Commands
{
	public class UpdateContactCommand : IRequest, IHasData<ContactDto>, IHasId
	{
		public ContactDto Data { get; set; }
		public Guid Id { get; set; }
	}
}