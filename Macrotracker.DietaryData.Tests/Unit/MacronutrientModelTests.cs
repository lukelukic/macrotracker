using FluentAssertions;
using MacroTracker.DietaryData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Macrotracker.DietaryData.Tests.Unit
{
    public class MacronutrientModelTests
    {
        [Theory]
        [InlineData(1,1,1,17)]
        [InlineData(100,100,50, 1250)]
        [InlineData(25,25,25, 425)]
        public void CalorieCalculationIsPrecise(double protein, double carbs, double fat, double expected)
        {
            var model = new MacronutrientModel
            {
                Protein = protein,
                Fat = fat,
                Carbohydrate = carbs
            };

            model.TotalKcal.Should().Be(expected);
        }
    }
}
