using MacroTracker.DietaryData.Models;

namespace MacroTracker.DietaryData.Repository
{
    public interface IFoodEntryRepository : IRepository<FoodEntry>
    {
        FoodEntry Find(string userId, string entryId);
    }
}