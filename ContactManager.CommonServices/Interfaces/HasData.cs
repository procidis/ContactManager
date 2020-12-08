using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.CommonServices.Interfaces
{
	public interface IHasData<TData>
	{
		TData Data { get; set; }
	}
}
