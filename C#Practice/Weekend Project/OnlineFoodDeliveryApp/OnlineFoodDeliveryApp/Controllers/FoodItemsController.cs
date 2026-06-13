using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.API.Models;
using OnlineFoodDeliveryApp.Services.Interfaces;

namespace OnlineFoodDeliveryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemService _foodItemService;

        public FoodItemsController(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        // GET: api/fooditems
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _foodItemService.GetAllAsync();
            return Ok(items);
        }

        // GET: api/fooditems/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _foodItemService.GetByIdAsync(id);

            if (item == null)
                return NotFound($"Food item with id {id} not found");

            return Ok(item);
        }

        // POST: api/fooditems
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FoodItem foodItem)
        {
            if (foodItem == null)
                return BadRequest("Invalid data");

            await _foodItemService.AddAsync(foodItem);

            return Ok("Food item created successfully");
        }

        // PUT: api/fooditems
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FoodItem foodItem)
        {
            if (foodItem == null)
                return BadRequest("Invalid data");

            await _foodItemService.UpdateAsync(foodItem);

            return Ok("Food item updated successfully");
        }

        // DELETE: api/fooditems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _foodItemService.DeleteAsync(id);

            return Ok("Food item deleted successfully");
        }
    }
}