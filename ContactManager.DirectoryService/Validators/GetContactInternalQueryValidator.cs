using ContactManager.DirectoryService.Queries;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators
{
	public class GetContactInternalQueryValidator : AbstractValidator<GetContactInternalQuery>
	{
		public GetContactInternalQueryValidator()
		{
			RuleFor(w => w.Id)
				.MustBeNonEmptyObjectId();
		}
	}
}
