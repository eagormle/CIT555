using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PackAPI.Interfaces;
using PackAPI.Models;
using PackAPI.Utils;

namespace PackAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _userRepository.GetByUsernameAsync(request.Username);

                if (user != null && _userService.ValidatePassword(request.Password, user.PasswordSalt, user.PasswordHash))
                {
                    var token = _userService.GenerateJwtToken(user);

                    return new JsonResult(new
                    {
                        Message = "Login successful",
                        Token = token
                    });
                }
                else
                {
                    return Unauthorized("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return BadRequest("An error occurred while processing the request.");
            }
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

                return new JsonResult(new
                {
                    Message = "User created successfully!",
                    user.UserId,
                    user.Username
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    Message = "Error in User Creation!",
                });
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

