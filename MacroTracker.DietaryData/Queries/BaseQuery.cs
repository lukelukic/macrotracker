using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MacroTracker.DietaryData.Queries
{
    public abstract class BaseQuery<T>
    {
        public abstract Expression<Func<T, bool>> GetQuery { get; }
    }
}
