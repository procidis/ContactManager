using System.Threading.Tasks;
using ContactManager.ModelLayer;
using MediatR;

namespace ContactManager.CommonServices.Interfaces
{
	public interface IServiceProcessor
	{
		Task<ServiceResponse<TResponse>> HandleAsync<TResponse>(IRequest<TResponse> request);
		Task<ServiceResponse<Unit>> HandleVoidAsync(IRequest request);
	}
}
