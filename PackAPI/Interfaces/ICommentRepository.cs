using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(Guid id);
        Task<IEnumerable<Comment>> GetByListIdAsync(Guid listId);
        Task AddAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(Guid id);
    }
}

