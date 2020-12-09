using ContactManager.DirectoryService.Commands;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators
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