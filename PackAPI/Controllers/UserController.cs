using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PackAPI.Interfaces;
using PackAPI.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
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

        [HttpPost]
        public async Task<ActionResult> AddAsync(User user)
        {
            await _userRepository.AddAsync(user);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = user.UserId }, user);
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

