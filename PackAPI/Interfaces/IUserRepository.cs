using PackAPI.Models;
using PackAPIAPI.Models;
using System.Net;

namespace PackAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user, string password);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
