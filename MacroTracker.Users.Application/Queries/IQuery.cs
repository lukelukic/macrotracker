using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MacroTracker.Users.Application.Queries
{
    public interface IQuery<T>
    {
        Expression<Func<T,bool>> AsQuery { get; }
    }
}
