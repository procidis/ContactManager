using ContactManager.DirectoryService.Queries.ContactSections;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators.Sections
{
	public class GetContactSectionsByUserInternalQueryValidator : AbstractValidator<GetContactSectionsByUserInternalQuery>
	{
		public GetContactSectionsByUserInternalQueryValidator()
		{
			RuleFor(w => w.ContactId)
				.NotEmpty()
				.NotNull();
		}
	}
}