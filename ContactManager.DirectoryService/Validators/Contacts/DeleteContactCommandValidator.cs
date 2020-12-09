using ContactManager.DirectoryService.Commands.Contacts;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators.Contacts
{
	public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
	{
		public DeleteContactCommandValidator()
		{
			RuleFor(w => w.Id)
				.MustBeNonEmptyObjectId();
		}
	}
}