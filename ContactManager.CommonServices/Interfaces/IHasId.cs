using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.CommonServices.Interfaces
{
	public interface IHasId
	{
		Guid Id { get; set; }
	}
}
