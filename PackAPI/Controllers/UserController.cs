using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PackAPI.Interfaces;
using PackAPI.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //[HttpPost]
        //public async Task<ActionResult> AddAsync(User user, String password)
        //{
        //   await _userRepository.AddAsync(user, password);

        //           return CreatedAtAction(nameof(GetByIdAsync), new { id = user.UserId }, user);
        //    }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CreateUserRequest request)
        {
            try
            {
                var user = new User
                {
                    Username = request.Username,
                    IsAdmin = request.IsAdmin
                };

                // Generate a new GUID for the UserId
                user.UserId = Guid.NewGuid();

                // Set the CreatedAt date to the current datetime
                user.CreatedAt = DateTime.UtcNow;

                // Generate a new salt and hash for the password
                byte[] salt;
                byte[] hash;
                using (var pbkdf2 = new Rfc2898DeriveBytes(request.Password, 16, 10000))
                {
                    salt = pbkdf2.Salt;
                    hash = pbkdf2.GetBytes(32);
                }
                user.PasswordSalt = salt;
                user.PasswordHash = hash;

                await _userRepository.AddAsync(user);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            await _userRepository.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(id);

            return NoContent();
        }
    }

}

