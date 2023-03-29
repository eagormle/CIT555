using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface IReplyDislikeRepository
    {
        Task<ReplyDislike> GetByIdAsync(Guid id);
        Task<IEnumerable<ReplyDislike>> GetByReplyIdAsync(Guid replyId);
        Task AddAsync(ReplyDislike replyDislike);
        Task DeleteAsync(Guid id);
    }

}

