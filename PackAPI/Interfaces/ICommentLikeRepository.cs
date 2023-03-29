using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface ICommentLikeRepository
    {
        Task<CommentLike> GetByIdAsync(Guid id);
        Task<IEnumerable<CommentLike>> GetByCommentIdAsync(Guid commentId);
        Task AddAsync(CommentLike commentLike);
        Task DeleteAsync(Guid id);
    }
}

