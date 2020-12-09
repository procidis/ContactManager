using ContactManager.DirectoryService.Queries.ContactSections;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators.ContactSections
{
	public class GetContactSectionInternalQueryValidator : AbstractValidator<GetContactSectionInternalQuery>
	{
		public GetContactSectionInternalQueryValidator()
		{
			RuleFor(w => w.Id)
				.MustBeNonEmptyGuid();
		}
	}
}
