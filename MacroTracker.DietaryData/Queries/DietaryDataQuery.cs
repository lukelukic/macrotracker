using MacroTracker.DietaryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MacroTracker.DietaryData.Queries
{
    public class DietaryDataQuery : BaseQuery<FoodEntryModel>
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override Expression<Func<FoodEntryModel, bool>> GetQuery =>
            f => f.AddedDate > StartDate && f.AddedDate < EndDate && f.UserId == UserId;
    }
}
