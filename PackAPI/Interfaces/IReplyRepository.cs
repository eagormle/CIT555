using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface IReplyRepository
    {
        Task<Reply> GetByIdAsync(Guid id);
        Task<IEnumerable<Reply>> GetByCommentIdAsync(Guid commentId);
        Task AddAsync(Reply reply);
        Task UpdateAsync(Reply reply);
        Task DeleteAsync(Guid id);
    }
}

