using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BUKEP.DATA
{
	public interface IRepository<TEntity> where TEntity : class
	{
		bool Add(TEntity entity);

		bool Add(ICollection<TEntity> entities);

		Task<bool> AddAsync(TEntity entity);

		Task<bool> AddAsync(ICollection<TEntity> entities);

		bool Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties);

		bool Update(ICollection<TEntity> entities, params Expression<Func<TEntity, object>>[] properties);

		Task<bool> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] properties);

		Task<bool> UpdateAsync(ICollection<TEntity> entities, params Expression<Func<TEntity, object>>[] properties);

		bool Remove(TEntity entity);

		bool Remove(ICollection<TEntity> entities);

		bool Remove(Expression<Func<TEntity, bool>> predicate);

		Task<bool> RemoveAsync(TEntity entity);

		Task<bool> RemoveAsync(ICollection<TEntity> entities);

		Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate);

		List<TEntity> Get(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate);

		TEntity Get(Func<IQueryable<TEntity>, TEntity> predicate);

		Task<TEntity> GetAsync(Func<IQueryable<TEntity>, Task<TEntity>> predicate);

		Task<List<TEntity>> GetAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate);
    }
}
