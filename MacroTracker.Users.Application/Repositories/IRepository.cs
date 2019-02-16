using MacroTracker.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MacroTracker.Users.Application.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int perPage = 50, int pageNumber = 1);

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        T Get(Guid id);

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Guid id);
    }
}