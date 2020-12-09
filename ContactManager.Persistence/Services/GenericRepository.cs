using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ContactManager.Persistence.Interfaces;
using ContactManager.Persistence.Models;
using ContactManager.Persistence.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ContactManager.Persistence.Implementations
{
	public class GenericRepository<TData> : IGenericRepository<TData> where TData : BaseModel
	{
		private readonly IMongoCollection<TData> collection;
		public GenericRepository(IOptions<DBSettings> options)
		{
			if (string.IsNullOrWhiteSpace(options.Value?.ConnectionString))
			{
				throw new ArgumentNullException(nameof(DBSettings));
			}

			var client = new MongoClient(options.Value.ConnectionString);
			var database = client.GetDatabase(options.Value.Database);
			collection = database.GetCollection<TData>(typeof(TData).Name);
		}

		public async Task<TData> CreateAsync(TData data)
		{
			data.CreatedAt = DateTime.Now;
			await collection.InsertOneAsync(data);
			return data;
		}


		public async Task<List<TData>> FilterAsync(Expression<Func<TData, bool>> expression)
		{
			var result = await (await collection.FindAsync(expression)).ToListAsync();
			return result.ToList();
		}

		public async Task<List<TData>> GetAllAsync()
		{
			var result = await collection.AsQueryable().ToListAsync();
			return result;
		}

		public async Task<TData> GetOneAsync(string id)
		{
			return await (await collection.FindAsync(w => w.Id == id)).FirstOrDefaultAsync();
		}

		public async Task<bool> RemoveAsync(TData data)
		{
			return await RemoveAsync(data);
		}

		public async Task<bool> RemoveAsync(string id)
		{
			var result = await collection.DeleteOneAsync(w => w.Id == id);
			return result.IsAcknowledged;
		}

		public async Task<bool> UpdateAsync(TData data)
		{
			data.UpdatedAt = DateTime.Now;
			var result = await collection.ReplaceOneAsync(w => w.Id == data.Id, data);
			return result.IsAcknowledged;
		}
	}
}
