using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BUKEP.DATA.Db
{
	public class EfRepository<TContext, TEntity> : IDbRepository<TEntity> where TContext : DbContext where TEntity : class
	{
		private DbSet<TEntity> _dbSet;
		private readonly TContext _context;

		public EfRepository(TContext context)
		{
			_context = context;
		}

		public IQueryable<TEntity> Table => _dbSet ??= _context.Set<TEntity>();

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public bool Add(TEntity entity)
		{
			if (entity == null)
			{
				return true;
			}
			_context.Entry(entity).State = EntityState.Added;
			_context.SaveChanges();

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public bool Add(ICollection<TEntity> entities)
		{
			if (entities == null || !entities.Any())
			{
				return true;
			}

			foreach (var entity in entities)
			{
				_context.Entry(entity).State = EntityState.Added;
			}

			_context.SaveChanges();

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<bool> AddAsync(TEntity entity)
		{
			if (entity == null)
			{
				return true;
			}

			_context.Entry(entity).State = EntityState.Added;
			await _context.SaveChangesAsync().ConfigureAwait(false);

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<bool> AddAsync(ICollection<TEntity> entities)
		{
			if (entities == null || !entities.Any())
			{
				return true;
			}
			foreach (var entity in entities)
			{
				_context.Entry(entity).State = EntityState.Added;
			}

			await _context.SaveChangesAsync().ConfigureAwait(false);

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public bool Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
		{
			if (entity == null)
			{
				return true;
			}

			if (properties.Any())
			{
				foreach (var property in properties)
				{
					_context.Entry(entity).Property(property).IsModified = true;
				}
			}
			else
			{
				_context.Entry(entity).State = EntityState.Modified;
			}

			_context.SaveChanges();

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public bool Update(ICollection<TEntity> entities, params Expression<Func<TEntity, object>>[] properties)
		{
			if (entities == null || !entities.Any())
			{
				return true;
			}

			foreach (var entity in entities)
			{
				if (properties.Any())
				{
					foreach (var property in properties)
					{
						_context.Entry(entity).Property(property).IsModified = true;
					}
				}
				else
				{
					_context.Entry(entity).State = EntityState.Modified;
				}
			}

			_context.SaveChanges();

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<bool> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
		{
			if (entity == null)
			{
				return true;
			}

			if (properties.Any())
			{
				foreach (var property in properties)
				{
					_context.Entry(entity).Property(property).IsModified = true;
				}
			}
			else
			{
				_context.Entry(entity).State = EntityState.Modified;
			}

			await _context.SaveChangesAsync().ConfigureAwait(false);

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<bool> UpdateAsync(ICollection<TEntity> entities, params Expression<Func<TEntity, object>>[] properties)
		{
			if (entities == null || !entities.Any())
			{
				return true;
			}

			foreach (var entity in entities)
			{
				if (properties.Any())
				{
					foreach (var property in properties)
					{
						_context.Entry(entity).Property(property).IsModified = true;
					}
				}
				else
				{
					_context.Entry(entity).State = EntityState.Modified;
				}
			}

			await _context.SaveChangesAsync().ConfigureAwait(false);

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public bool Remove(TEntity entity)
		{
			if (entity == null)
			{
				return true;
			}

			_context.Entry(entity).State = EntityState.Deleted;
			_context.SaveChanges();

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public bool Remove(ICollection<TEntity> entities)
		{
			if (entities == null || !entities.Any())
			{
				return true;
			}

			foreach (var entity in entities)
			{
				_context.Entry(entity).State = EntityState.Deleted;
			}

			_context.SaveChanges();

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public bool Remove(Expression<Func<TEntity, bool>> predicate)
		{
			if (predicate == null)
			{
				return true;
			}

			var entities = _context.Set<TEntity>().AsTracking().Where(predicate);

			if (!entities.Any())
			{
				return true;
			}

			foreach (var entity in entities)
			{
				_context.Entry(entity).State = EntityState.Deleted;
			}

			_context.SaveChanges();

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<bool> RemoveAsync(TEntity entity)
		{
			if (entity == null)
			{
				return true;
			}

			_context.Entry(entity).State = EntityState.Deleted;
			await _context.SaveChangesAsync().ConfigureAwait(false);

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<bool> RemoveAsync(ICollection<TEntity> entities)
		{
			if (entities == null || !entities.Any())
			{
				return true;
			}

			foreach (var entity in entities)
			{
				_context.Entry(entity).State = EntityState.Deleted;
			}

			await _context.SaveChangesAsync().ConfigureAwait(false);

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate)
		{
			if (predicate == null)
			{
				return true;
			}
			var entities = _context.Set<TEntity>().AsTracking().Where(predicate);

			if (!entities.Any())
			{
				return true;
			}

			foreach (var entity in entities)
			{
				_context.Entry(entity).State = EntityState.Deleted;
			}

			await _context.SaveChangesAsync().ConfigureAwait(false);

			return true;
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public List<TEntity> Get(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate)
		{
			return predicate == null ? new List<TEntity>() : predicate(Table).ToList();
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public TEntity Get(Func<IQueryable<TEntity>, TEntity> predicate)
		{
			return predicate?.Invoke(Table);
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<List<TEntity>> GetAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate)
		{
			return predicate == null
				? new List<TEntity>()
				: await predicate(Table).ToListAsync().ConfigureAwait(false);
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task<TEntity> GetAsync(Func<IQueryable<TEntity>, Task<TEntity>> predicate)
		{
			return predicate == null ? null : await predicate(Table);
		}
	}
}
