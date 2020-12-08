using System;
using System.Threading.Tasks;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using FluentValidation;
using MediatR;

namespace ContactManager.CommonServices.Services
{
	public class ServiceProcessor : IServiceProcessor
	{
		private const string UNHANDLED_EXCEPTION_CODE = "unhandled_exception";
		private readonly IMediator mediator;
		private readonly ITicketService ticketService;

		public ServiceProcessor(IMediator mediator, ITicketService ticketService)
		{
			this.mediator = mediator;
			this.ticketService = ticketService;
		}
		public async Task<ServiceResponse<TResponse>> HandleAsync<TResponse>(IRequest<TResponse> request)
		{
			return await CallAsync(async () =>
			{
				return await mediator.Send(request);
			});
		}

		public async Task<ServiceResponse<Unit>> HandleVoidAsync(IRequest request)
		{
			return await CallAsync(async () =>
			{
				return await mediator.Send(request);
			});
		}

		private async Task<ServiceResponse<TResponse>> CallAsync<TResponse>(Func<Task<TResponse>> action)
		{
			var result = default(TResponse);
			string errorCode = null;
			Exception exception = null;
			try
			{
				result = await action();
			}
			catch (ValidationException ex)
			{
				throw ex;
			}
			catch (ServiceException ex)
			{
				exception = ex;
				errorCode = ex.ErrorCode;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			return CreateResponse(result, exception, errorCode);
		}

		private ServiceResponse<TResponse> CreateResponse<TResponse>(TResponse result, Exception ex, string errorCode = null)
		{
			var response = new ServiceResponse<TResponse>()
			{
				Succeeded = true,
				Ticket = ticketService.Ticket,
				ErrorCode = errorCode
			};

			if (ex != null)
			{
				response.Succeeded = false;
				response.ErrorCode = errorCode ?? UNHANDLED_EXCEPTION_CODE;
			}
			else
			{
				response.Result = result;
			}
			return response;
		}
	}
}
