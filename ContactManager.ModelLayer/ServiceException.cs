using System;

namespace ContactManager.ModelLayer
{
	public class ServiceException : Exception
	{
		public string ErrorCode { get; set; }
		public Guid Ticket { get; set; }
	}
}
