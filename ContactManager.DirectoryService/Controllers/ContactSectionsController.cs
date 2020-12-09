using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManager.CommonServices.Implementations;
using ContactManager.CommonServices.Interfaces;
using ContactManager.DirectoryService.Commands.ContactSections;
using ContactManager.DirectoryService.Queries.ContactSections;
using ContactManager.ModelLayer;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.DirectoryService.Controllers
{
	public class ContactSectionsController : ControllerImplBase<ContactSectionDto,
		GetContactSectionsInternalQuery,
		GetContactSectionInternalQuery,
		CreateContactSectionCommand,
		UpdateContactSectionCommand,
		DeleteContactSectionCommand>
	{
		public ContactSectionsController(IServiceProcessor serviceProcessor) : base(serviceProcessor)
		{
		}

		[HttpGet()]
		public async Task<ServiceResponse<IEnumerable<ContactSectionDto>>> GetByUser([FromQuery] string userId)
		{
			var query = new GetContactSectionsByUserInternalQuery
			{
				UserId = userId
			};
			return await serviceProcessor.HandleAsync(query);
		}

		[NonAction]
		public override Task<ServiceResponse<IEnumerable<ContactSectionDto>>> Get()
		{
			throw new NotImplementedException();
		}
	}
}
