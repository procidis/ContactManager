using ContactManager.DirectoryService.Commands;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators
{
	public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
	{
		public CreateContactCommandValidator()
		{
			RuleFor(w => w.Data)
				.NotNull();
			RuleFor(w => w.Data.Company)
				.NotNull()
				.NotEmpty();
			RuleFor(w => w.Data.Name)
				.NotNull()
				.NotEmpty();
			RuleFor(w => w.Data.Sections)
				.NotNull()
				.NotEmpty();
			RuleFor(w => w.Data.Surname)
				.NotNull()
				.NotEmpty();
			RuleFor(w => w.Data.UUID)
				.NotNull()
				.NotEmpty();
		}
	}
}