using MacroTracker.DietaryData.Calculation;
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
        public ActionResult<IEnumerable<FoodEntryModel>> Get([FromQuery] DietaryDataQuery query)
        {
            var items = _repo.Get(query);
            return Ok(items);
        }

        // POST api/values
        [HttpPost("api/entries/{userId}")]
        public void Post(string userId, [FromBody] MacronutrientModel model)
        {
            var entry = new FoodEntryModel
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

        [HttpDelete("api/entries/{entryId}")]
        public IActionResult Delete(string entryId)
        {
            if (!_repo.Get(e => e.Id == ObjectId.Parse(entryId)).Any())
                return NotFound($"Entry with provided id doesn't exist.");

            _repo.Delete(entryId);
            return NoContent();
        }

        [HttpPost("api/entries/{userId}/{calories}")]
        public IActionResult AddEntryFromCalories(string userId, double calories)
        {
            try
            {
                _repo.Insert(new FoodEntryModel
                {
                    KCal = calories,
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

        [HttpGet("api/entries/{entryId}")]
        public IActionResult Get(string entryId)
        {
            var item = _repo.Find(entryId);
            return item == null ? NotFound() : (IActionResult)Ok(item);
        }

        [HttpPut("api/entries/{entryId}")]
        public IActionResult Put(string entryId, [FromBody]MacronutrientModel model)
        {
            var previousEntry = _repo.Find(entryId);
            if (previousEntry == null)
                return NotFound($"Entry with provided id doesn't exist.");

            var entry = new FoodEntryModel
            {
                Id = ObjectId.Parse(entryId),
                Fat = model.Fat,
                Carbohydrate = model.Carbohydrate,
                Protein = model.Protein,
                KCal = model.TotalKcal,
                UserId = previousEntry.UserId,
                AddedDate = previousEntry.AddedDate
            };

            _repo.Update(entry);
            return NoContent();
        }
    }
}