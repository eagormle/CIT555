using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface IListRepository
    {
        Task<IEnumerable<List>> GetAllAsync(string username);
        Task<List> GetByIdAsync(Guid id);
        Task AddAsync(List list);
        Task UpdateAsync(List list);
        Task DeleteAsync(Guid id);
    }
}

