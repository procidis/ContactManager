using ContactManager.DirectoryService.Commands.ContactSections;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators.ContactSections
{
	public class UpdateContactSectionCommandValidator : AbstractValidator<UpdateContactSectionCommand>
	{
		public UpdateContactSectionCommandValidator()
		{
			RuleFor(w => w.Id)
				.MustBeNonEmptyGuid();
			RuleFor(w => w.Data)
				.NotNull();
			RuleFor(w => w.Data.Detail)
				.NotNull()
				.NotEmpty();
			RuleFor(w => w.Data.Type)
				.NotEmpty();
		}
	}
}