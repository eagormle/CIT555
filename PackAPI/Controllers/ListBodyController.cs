using Microsoft.AspNetCore.Mvc;
using PackAPI.Interfaces;
using PackAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListBodyController : ControllerBase
    {
        private readonly IListBodyRepository _listBodyRepository;

        public ListBodyController(IListBodyRepository listBodyRepository)
        {
            _listBodyRepository = listBodyRepository;
        }

        // GET: api/ListBody/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ListBody>> GetByIdAsync(Guid id)
        {
            var listBody = await _listBodyRepository.GetByIdAsync(id);

            if (listBody == null)
            {
                return NotFound();
            }

            return Ok(listBody);
        }

        // GET: api/ListBody/List/{listId}
        [HttpGet("List/{listId}")]
        public async Task<ActionResult<IEnumerable<ListBody>>> GetByListIdAsync(Guid listId)
        {
            var listBodies = await _listBodyRepository.GetByListIdAsync(listId);

            return Ok(listBodies);
        }

        // POST: api/ListBody
        [HttpPost]
        public async Task<ActionResult<ListBody>> AddAsync(ListBody listBody)
        {
            await _listBodyRepository.AddAsync(listBody);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = listBody.ListBodyId }, listBody);
        }

        // PUT: api/ListBody/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, ListBody listBody)
        {
            if (id != listBody.ListBodyId)
            {
                return BadRequest();
            }

            await _listBodyRepository.UpdateAsync(listBody);

            return NoContent();
        }

        // DELETE: api/ListBody/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var listBody = await _listBodyRepository.GetByIdAsync(id);

            if (listBody == null)
            {
                return NotFound();
            }

            await _listBodyRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
