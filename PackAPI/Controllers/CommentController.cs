using Microsoft.AspNetCore.Mvc;
using PackAPI.Interfaces;
using PackAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetByIdAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpGet("list/{listId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetByListIdAsync(Guid listId)
        {
            var comments = await _commentRepository.GetByListIdAsync(listId);

            return Ok(comments);
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> AddAsync([FromBody] Comment comment)
        {
            await _commentRepository.AddAsync(comment);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = comment.CommentId }, comment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            await _commentRepository.UpdateAsync(comment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            await _commentRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
