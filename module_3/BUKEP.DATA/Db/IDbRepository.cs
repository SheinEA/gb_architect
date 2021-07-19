using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BUKEP.DATA.Db
{
	public interface IDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Table { get; }
	}
}
