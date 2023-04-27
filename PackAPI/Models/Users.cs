using System;
namespace PackAPI.Models
{
        public class User
        {
            public Guid UserId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public byte[] PasswordSalt { get; set; }
            public byte[] PasswordHash { get; set; }
            public bool IsAdmin { get; set; }
            public DateTime CreatedAt { get; set; }
        }
}

