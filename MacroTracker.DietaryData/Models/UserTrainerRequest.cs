using System;

namespace MacroTracker.DietaryData.Models
{
    public class UserTrainerRequest
    {
        public string UserId { get; set; }
        public string TrainerId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}