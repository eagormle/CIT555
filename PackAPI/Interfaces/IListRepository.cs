using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface IListRepository
    {
        Task<IEnumerable<ListBody>> GetAllAsync(string username);
        Task<ListBody> GetByIdAsync(Guid id);
        Task AddAsync(ListBody list);
        Task UpdateAsync(ListBody list);
        Task DeleteAsync(Guid id);
    }
}

