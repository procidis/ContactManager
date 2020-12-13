using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ContactManager.Persistence.Models;

namespace ContactManager.Persistence.Interfaces
{
	public interface IGenericRepository<TData> where TData : BaseModel
	{
		Task<TData> CreateAsync(TData data);
		Task<List<TData>> FilterAsync(Expression<Func<TData, bool>> expression);
		Task<TData> GetOneAsync(string id);
		Task<bool> RemoveAsync(string id);
		Task<bool> RemoveAsync(TData data);
		Task<bool> UpdateAsync(TData data);
		Task<List<TData>> GetAllAsync();
	}
}