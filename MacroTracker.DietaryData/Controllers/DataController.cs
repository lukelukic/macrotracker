using MacroTracker.DietaryData.Domain;
using MacroTracker.DietaryData.Models;
using MacroTracker.DietaryData.Queries;
using MacroTracker.DietaryData.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MacroTracker.DietaryData.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IFoodEntryRepository _repo;

        public DataController(IFoodEntryRepository repo) => _repo = repo;

        [Route("api/entries")]
        [HttpGet]
        public ActionResult<IEnumerable<FoodEntry>> Get([FromQuery] DietaryDataQuery query)
        {
            var items = _repo.Get(f => f.AddedDate > query.StartDate && f.AddedDate < query.EndDate && f.UserId == query.UserId);
            return Ok(items);
        }

        // POST api/values
        [HttpPost("api/entries/{userId}")]
        public void Post(string userId, [FromBody] MacronutrientModel model)
        {
            var entry = new FoodEntry
            {
                Protein = model.Protein,
                Fat = model.Fat,
                Carbohydrate = model.Carbohydrate,
                KCal = model.TotalKcal,
                AddedDate = DateTime.Now,
                UserId = userId
            };
            _repo.Insert(entry);
        }

        [HttpDelete("api/entries/{userId}/{entryId}")]
        public IActionResult Delete(string userId, string entryId)
        {
            if (!_repo.Get(e => e.UserId == userId && e.Id == ObjectId.Parse(entryId)).Any())
                return NotFound($"Entry with provided id doesn't exist or doesn't belong to specified user.");

            _repo.Delete(entryId);
            return NoContent();
        }

        [HttpPost("api/entries/{userId}/{calories}")]
        public IActionResult AddEntryFromCalories(string userId, double calories)
        {
            try
            {
                var food = new Food(calories);
                _repo.Insert(new FoodEntry
                {
                    KCal = food.Kcal,
                    AddedDate = DateTime.Now,
                    UserId = userId
                });
                return Ok();
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("api/entries/{userId}/{entryId}")]
        public IActionResult Get(string userId, string entryId)
        {
            var item = _repo.Find(userId, entryId);
            return item == null ? NotFound() : (IActionResult)Ok(item);
        }

        [HttpPut("api/entries/{userId}/{entryId}")]
        public IActionResult Put(string userId, string entryId, [FromBody]MacronutrientModel model)
        {
            if (_repo.Find(userId, entryId) == null)
                return NotFound($"Entry with provided id doesn't exist or doesn't belong to specified user.");

            var entry = new FoodEntry
            {
                Id = ObjectId.Parse(entryId),
                Fat = model.Fat,
                Carbohydrate = model.Carbohydrate,
                Protein = model.Protein,
                KCal = model.TotalKcal,
                UserId = userId
            };

            _repo.Update(entry);
            return NoContent();
        }
    }
}