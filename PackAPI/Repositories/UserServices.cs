﻿using Microsoft.IdentityModel.Tokens;
using PackAPI.Interfaces;
using PackAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;

    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool ValidatePassword(string password, byte[] salt, byte[] hash)
    {
        // Validate the password by comparing the hash of the supplied password with the stored hash
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            var computedHash = pbkdf2.GetBytes(32);
            return computedHash.SequenceEqual(hash);
        }
    }

    public string GenerateJwtToken(User user)
    {
        // Generate a new JWT token for the user
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Secret"));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
            }),
            Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt:ExpirationMinutes")),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}