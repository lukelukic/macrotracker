using System;

namespace MacroTracker.DietaryData.Domain
{
    public class Food
    {
        #region Static Members

        public static double Protein => 4;
        public static double Fat => 4;
        public static double Carbohydrate => 4;

        #endregion Static Members

        private double _kcal;

        #region Constructors

        protected Food()
        {
        }

        public Food(string name, double kcal)
        {
            if (kcal <= 0)
                throw new ArgumentOutOfRangeException("kcal");
            _kcal = kcal;
            Name = name;
        }

        public Food(string name) => Name = name;

        public Food(double kcal)
        {
            if (kcal <= 0)
                throw new ArgumentOutOfRangeException("kcal");
            _kcal = kcal;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; set; }

        public double Kcal
        {
            get => _kcal;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("kcal");
                _kcal = value;
            }
        }

        #endregion Properties
    }
}