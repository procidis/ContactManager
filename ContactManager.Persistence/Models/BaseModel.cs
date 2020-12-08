using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactManager.Persistence.Models
{
	public abstract class BaseModel
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public RecordStatus Status { get; set; }
	}

	public enum RecordStatus
	{
		Unset = 0,
		Active = 1,
		Deleted = 2
	}
}
