using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MacroTracker.DietaryData.Models
{
    public class FoodEntry
    {
        [BsonElement]
        public DateTime AddedDate { get; set; }

        [BsonElement]
        [Range(0, 1000)]
        public double Protein { get; set; }

        [BsonElement]
        [Range(0, 2000)]
        public double Fat { get; set; }

        [BindRequired]
        [Range(0, 2000)]
        public double Carbohydrate { get; set; }

        [Required]
        [Range(0, 20000)]
        public double KCal { get; set; }

        [BsonElement]
        [Required]
        public string UserId { get; set; }

        public ObjectId Id { get; set; }
    }
}