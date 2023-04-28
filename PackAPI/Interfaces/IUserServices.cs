using System;
using PackAPI.Models;

namespace PackAPI.Interfaces
{
    public interface IUserService
    {
        bool ValidatePassword(string password, byte[] salt, byte[] hash);
        string GenerateJwtToken(User user);
    }
}

