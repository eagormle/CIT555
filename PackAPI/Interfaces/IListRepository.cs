using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface IListRepository
    {
        Task<ListBody> GetByIdAsync(Guid id);
        Task<IEnumerable<ListBody>> GetByListIdAsync(Guid listId);
        Task AddAsync(ListBody listBody);
        Task UpdateAsync(ListBody listBody);
        Task DeleteAsync(Guid id);
    }
}

