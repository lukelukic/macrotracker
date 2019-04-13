using MacroTracker.DietaryData.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MacroTracker.DietaryData.Repository
{
    public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(string objectId);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Get(BaseQuery<TEntity> entity);
    }
}