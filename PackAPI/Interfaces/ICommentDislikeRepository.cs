using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface ICommentDislikeRepository
    {
        Task<CommentDislike> GetByIdAsync(Guid id);
        Task<IEnumerable<CommentDislike>> GetByCommentIdAsync(Guid commentId);
        Task AddAsync(CommentDislike commentDislike);
        Task DeleteAsync(Guid id);
    }
}

