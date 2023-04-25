using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PackAPI.Interfaces;
using PackAPI.Models;

namespace PackAPI.Controllers
{
    [ApiController]
    [Route("api/comments/{commentId}/likes")]
    public class CommentLikesController : ControllerBase
    {
        private readonly ICommentLikeRepository _commentLikeRepository;

        public CommentLikesController(ICommentLikeRepository commentLikeRepository)
        {
            _commentLikeRepository = commentLikeRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentLike>> GetById(Guid commentId, Guid id)
        {
            var commentLike = await _commentLikeRepository.GetByIdAsync(id);
            if (commentLike == null || commentLike.CommentId != commentId)
            {
                return NotFound();
            }

            return Ok(commentLike);
        }

        [HttpPost]
        public async Task<ActionResult<CommentLike>> Create(Guid commentId, CommentLike commentLike)
        {
            commentLike.CommentId = commentId;
            commentLike.CreatedAt = DateTime.UtcNow;

            await _commentLikeRepository.AddAsync(commentLike);

            return CreatedAtAction(nameof(GetById), new { commentId = commentId, id = commentLike.CommentLikeId }, commentLike);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid commentId, Guid id)
        {
            var commentLike = await _commentLikeRepository.GetByIdAsync(id);
            if (commentLike == null || commentLike.CommentId != commentId)
            {
                return NotFound();
            }

            await _commentLikeRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
