using MacroTracker.DietaryData.Models;

namespace MacroTracker.DietaryData.Repository
{
    public interface IFoodEntryRepository : IRepository<FoodEntryModel>
    {
        FoodEntryModel Find(string entryId);
    }
}