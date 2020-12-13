using System;
using FluentValidation;
using MongoDB.Bson;

namespace ContactManager.DirectoryService.Validators
{
	public static class CommonValidators
	{
		private const string NON_EPTY_OBJECT_ID_MESSAGE = "Field must be non-empty object id";
		private const string EPTY_OBJECT_ID_MESSAGE = "Field must be empty object id";

		private const string NON_EPTY_GUID_MESSAGE = "Field must be non-empty object id";
		private const string EPTY_GUID_MESSAGE = "Field must be empty object id";

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

		public static IRuleBuilderOptions<T, string> MustBeNonEmptyGuid<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder
				.NotEmpty()
				.Must(w => Guid.TryParse(w, out var objectId) && objectId != Guid.Empty)
				.WithMessage(NON_EPTY_GUID_MESSAGE);
		}


		public static IRuleBuilderOptions<T, string> MustBeEmptyGuid<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder
				.Empty()
				.Must(w => !Guid.TryParse(w, out var objectId) || objectId == Guid.Empty)
				.WithMessage(EPTY_GUID_MESSAGE);
		}
	}
}
