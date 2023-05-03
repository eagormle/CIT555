using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using PackAPI.Interfaces;
using PackAPI.Models;
using PackAPI.Utils;
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
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, PasswordHasherConstants.IterationCount, HashAlgorithmName.SHA256))
        {
            var computedHash = pbkdf2.GetBytes(PasswordHasherConstants.HashByteSize);
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
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddHours(24),
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
