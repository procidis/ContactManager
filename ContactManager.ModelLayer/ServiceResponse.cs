using System;

namespace ContactManager.ModelLayer
{
	public class ServiceResponse<T>
	{
		public T Result { get; set; }
		public Guid Ticket { get; set; }
		public bool Succeeded { get; set; }
		public string ErrorCode { get; set; }
		public string Message { get; set; }
	}
}
