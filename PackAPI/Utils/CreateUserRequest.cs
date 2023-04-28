using System;
namespace PackAPI.Utils
{
    public class CreateUserRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
