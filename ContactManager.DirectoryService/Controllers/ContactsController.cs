using ContactManager.CommonServices.Implementations;
using ContactManager.CommonServices.Interfaces;
using ContactManager.DirectoryService.Commands;
using ContactManager.DirectoryService.Queries;
using ContactManager.ModelLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.DirectoryService.Controllers
{
	public class ContactsController : ControllerImplBase<ContactDto,
		GetContactsInternalQuery,
		GetContactInternalQuery,
		CreateContactCommand,
		UpdateContactCommand,
		DeleteContactCommand>
	{
		public ContactsController(IServiceProcessor serviceProcessor) : base(serviceProcessor)
		{
		}
	}
}
