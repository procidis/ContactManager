﻿using System;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.DirectoryService.Queries
{
	public class GetContactInternalQuery : IRequest<ContactDto>, IHasId
	{
		public Guid Id { get; set; }
	}
}