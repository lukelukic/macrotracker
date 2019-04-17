using System;

namespace MacroTracker.DietaryData.Calculation
{
    public class CalorieCalculator
    {
        public static double Protein => 4;
        public static double Fat => 9;
        public static double Carbohydrate => 4;

        public static double Kcal(double protein, double carbohydrate, double fat)
            => protein * CalorieCalculator.Protein + fat * CalorieCalculator.Fat + carbohydrate * CalorieCalculator.Carbohydrate;
    }
}
