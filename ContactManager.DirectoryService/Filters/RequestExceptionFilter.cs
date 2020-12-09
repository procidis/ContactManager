using System.Net;
using ContactManager.ModelLayer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactManager.DirectoryService.Filters
{
	public class RequestExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
	{
		public override void OnException(ExceptionContext context)
		{
			if (context.Exception is ValidationException || context.Exception is ServiceException)
			{
				context.HttpContext.Response.ContentType = "application/json";
				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

				if (context.Exception is ValidationException exception)
				{
					context.Result = new JsonResult(exception.Errors);
				}
				if (context.Exception is ServiceException)
				{
					context.Result = new JsonResult(context.Exception.Message);
				}
			}
		}
	}
}
