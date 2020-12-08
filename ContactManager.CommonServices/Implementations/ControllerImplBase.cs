using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManager.CommonServices.Interfaces;
using ContactManager.ModelLayer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.CommonServices.Implementations
{
	[Route("api/[controller]")]
	[ApiController]
	public abstract class ControllerImplBase<TData, TGetAllQuery, TGetOneQuery, TCreateCommand, TUpdateCommand, TDeleteCommand> : ControllerBase
		where TGetAllQuery : IRequest<IEnumerable<TData>>
		where TGetOneQuery : IRequest<TData>, IHasId
		where TUpdateCommand : IRequest, IHasData<TData>, IHasId
		where TCreateCommand : IRequest<TData>, IHasData<TData>
		where TDeleteCommand : IRequest, IHasId
	{
		protected readonly IServiceProcessor serviceProcessor;
		public ControllerImplBase(IServiceProcessor serviceProcessor)
		{
			this.serviceProcessor = serviceProcessor;
		}

		// GET: api/<[TData]Controller>
		[HttpGet]
		public async Task<ServiceResponse<IEnumerable<TData>>> Get()
		{
			var query = Activator.CreateInstance<TGetAllQuery>();
			return await serviceProcessor.HandleAsync(query);
		}

		// GET api/<[TData]Controller>/blablabla
		[HttpGet("{id}")]
		public async Task<ServiceResponse<TData>> Get(string id)
		{
			var query = Activator.CreateInstance<TGetOneQuery>();
			query.Id = id;
			return await serviceProcessor.HandleAsync(query);
		}

		// POST api/<[TData]Controller>
		[HttpPost]
		public async Task<ServiceResponse<TData>> Post([FromBody] TCreateCommand command)
		{
			return await serviceProcessor.HandleAsync(command);
		}

		// PUT api/<[TData]Controller>/blablabla
		[HttpPut("{id}")]
		public async Task Put(string id, [FromBody] TUpdateCommand command)
		{
			command.Id = id;
			await serviceProcessor.HandleVoidAsync(command);
		}

		// DELETE api/<[TData]Controller>/blablabla
		[HttpDelete("{id}")]
		public async Task Delete(string id)
		{
			var command = Activator.CreateInstance<TDeleteCommand>();
			command.Id = id;
			await serviceProcessor.HandleVoidAsync(command);
		}
	}
}
