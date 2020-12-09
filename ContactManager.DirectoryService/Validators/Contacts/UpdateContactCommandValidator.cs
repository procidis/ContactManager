using ContactManager.DirectoryService.Commands.Contacts;
using FluentValidation;

namespace ContactManager.DirectoryService.Validators.Contacts
{
	public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
	{
		public UpdateContactCommandValidator()
		{
			RuleFor(w => w.Id)
				.MustBeNonEmptyObjectId();
			RuleFor(w => w.Data)
				.NotNull();
			RuleFor(w => w.Data.Company)
				.NotNull()
				.NotEmpty();
			RuleFor(w => w.Data.Name)
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