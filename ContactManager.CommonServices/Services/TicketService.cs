using System;
using ContactManager.CommonServices.Interfaces;

namespace ContactManager.CommonServices.Services
{
	public class TicketService : ITicketService
	{
		public TicketService()
		{
			Ticket = Guid.NewGuid();
		}

		public Guid Ticket { get; set; }
	}
}
