using System;

namespace ContactManager.ModelLayer
{
	public class ServiceException : Exception
	{
		public ServiceException(string errorCode, string message) : base(message)
		{
			ErrorCode = errorCode;
		}

		public string ErrorCode { get; set; }
	}
}
