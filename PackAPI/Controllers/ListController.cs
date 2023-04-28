using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PackAPI.Interfaces;
using PackAPI.Models;
using PackAPI.Utils;

namespace PackAPI.Controllers
{
    [ApiController]
    [Route("api/lists")]
    public class ListsController : ControllerBase
    {
        private readonly IListRepository _listRepository;

        public ListsController(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List>> GetListById(Guid id)
        {
            var list = await _listRepository.GetByIdAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        //[HttpGet("user/{userId}")]
        //public async Task<ActionResult> GetListsByUserId(Guid userId)
        //{
        //    var lists = await _listRepository.GetByUserIdAsync(userId);
        //    return Ok(lists);
        //}

        [HttpGet("user/{username}")]
        public async Task<ActionResult> GetListsByUsername(string username)
        {
            var lists = await _listRepository.GetAllAsync(username);
            return Ok(lists);
        }

        [HttpPost]
        public async Task<ActionResult> CreateList([FromBody] CreateListRequest request)
        {
            var list = new List
            {
                UserId = request.UserId,
                ListName = request.ListName
            };

            await _listRepository.AddAsync(list);
            return CreatedAtAction(nameof(GetListById), new { id = list.ListId }, list);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateList(Guid id, List list)
        {
            if (id != list.ListId)
            {
                return BadRequest();
            }

            await _listRepository.UpdateAsync(list);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteList(Guid id)
        {
            await _listRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
