using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ItemsDotNetApi.Entity;
using ItemsDotNetApi.Services;

namespace ItemsDotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Item item)
        {
            var createdItem = await _itemService.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Item updatedItem)
        {
            var item = await _itemService.UpdateAsync(id, updatedItem);
            if (item == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemService.DeleteAsync(id);
            if (item == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
