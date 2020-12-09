using FluentValidation;
using MongoDB.Bson;

namespace ContactManager.DirectoryService.Validators
{
	public static class CommonValidators
	{
		private const string NON_EPTY_OBJECT_ID_MESSAGE = "Field must be non-empty object id";
		private const string EPTY_OBJECT_ID_MESSAGE = "Field must be empty object id";
		public static IRuleBuilderOptions<T, string> MustBeNonEmptyObjectId<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder
				.NotEmpty()
				.Must(w => ObjectId.TryParse(w, out var objectId) && objectId != ObjectId.Empty)
				.WithMessage(NON_EPTY_OBJECT_ID_MESSAGE);
		}


		public static IRuleBuilderOptions<T, string> MustBeEmptyObjectId<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder
				.Empty()
				.Must(w => !ObjectId.TryParse(w, out var objectId) || objectId == ObjectId.Empty)
				.WithMessage(EPTY_OBJECT_ID_MESSAGE);
		}
	}
}
