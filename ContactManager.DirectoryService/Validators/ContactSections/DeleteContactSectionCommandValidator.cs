using ContactManager.DirectoryService.Commands.ContactSections;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators.ContactSections
{
	public class DeleteContactSectionCommandValidator : AbstractValidator<DeleteContactSectionCommand>
	{
		public DeleteContactSectionCommandValidator()
		{
			RuleFor(w => w.Id)
				.MustBeNonEmptyGuid();
		}
	}
}