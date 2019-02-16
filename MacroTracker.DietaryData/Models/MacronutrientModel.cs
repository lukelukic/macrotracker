using MacroTracker.DietaryData.Domain;
using System.ComponentModel.DataAnnotations;

namespace MacroTracker.DietaryData.Models
{
    public class MacronutrientModel
    {
        [Range(0, 1000)]
        public double Protein { get; set; }

        [Range(0, 2000)]
        public double Fat { get; set; }

        [Range(0, 2000)]
        public double Carbohydrate { get; set; }

        public double TotalKcal =>
            (Protein * Food.Protein) + (Carbohydrate * Food.Carbohydrate) + (Fat * Food.Fat);
    }
}