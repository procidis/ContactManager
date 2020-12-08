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
			if (string.IsNullOrWhiteSpace(options.Value?.ConnectionString) || string.IsNullOrWhiteSpace(options.Value?.DBName))
			{
				throw new ArgumentNullException(nameof(DBSettings));
			}

			var client = new MongoClient(options.Value.ConnectionString);
			var database = client.GetDatabase(options.Value.DBName);
			collection = database.GetCollection<TData>(typeof(TData).Name);
		}

		public TData Create(TData data)
		{
			var task = CreateAsync(data);
			task.Wait();
			return task.Result;
		}

		public async Task<TData> CreateAsync(TData data)
		{
			data.CreatedAt = DateTime.Now;
			data.Status = RecordStatus.Active;
			await collection.InsertOneAsync(data);
			return data;
		}

		public List<TData> Filter(Expression<Func<TData, bool>> expression)
		{
			var task = FilterAsync(expression);
			task.Wait();
			return task.Result;
		}

		public async Task<List<TData>> FilterAsync(Expression<Func<TData, bool>> expression)
		{
			var result = await (await collection.FindAsync(expression)).ToListAsync();
			return result.Where(w => w.Status == RecordStatus.Active).ToList();
		}

		public List<TData> GetAll()
		{
			var task = GetAllAsync();
			task.Wait();
			return task.Result;
		}

		public async Task<List<TData>> GetAllAsync()
		{
			var result = await (await collection.FindAsync(w => w.Status == RecordStatus.Active)).ToListAsync();
			return result;
		}

		public TData GetOne(string id)
		{
			var task = GetOneAsync(id);
			task.Wait();
			return task.Result;
		}

		public async Task<TData> GetOneAsync(string id)
		{
			return await (await collection.FindAsync(w => w.Id == id && w.Status == RecordStatus.Active)).FirstOrDefaultAsync();
		}

		public bool Remove(TData data)
		{
			var task = RemoveAsync(data);
			task.Wait();
			return task.Result;
		}

		public bool Remove(string id)
		{
			var task = RemoveAsync(id);
			task.Wait();
			return task.Result;
		}

		public async Task<bool> RemoveAsync(TData data)
		{
			data.UpdatedAt = DateTime.Now;
			data.Status = RecordStatus.Deleted;
			var result = await collection.ReplaceOneAsync(w => w.Id == data.Id, data);
			return result.IsAcknowledged;
		}

		public async Task<bool> RemoveAsync(string id)
		{
			var data = await GetOneAsync(id);
			data.Status = RecordStatus.Deleted;
			return Update(data);
		}

		public bool Update(TData data)
		{
			data.UpdatedAt = DateTime.Now;
			var task = collection.ReplaceOneAsync(w => w.Id == data.Id, data);
			task.Wait();
			return task.Result.IsAcknowledged;
		}

		public async Task<bool> UpdateAsync(TData data)
		{
			data.UpdatedAt = DateTime.Now;
			var result = await collection.ReplaceOneAsync(w => w.Id == data.Id, data);
			return result.IsAcknowledged;
		}
	}
}
