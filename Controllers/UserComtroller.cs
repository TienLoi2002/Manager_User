using Manager_User_API.DTO;
using Manager_User_API.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public UserController(IUserService userService)
        {
            _userService = userService;
           
        }

      

        [HttpGet]
        [Route("/api/[controller]/get-all-users")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("/api/[controller]/add-user")]
        public async Task<IActionResult> AddAsync([FromBody] UserDTO user)
        {
            var createdUser = await _userService.AddAsync(user);
            if (createdUser == null)
            {
                return BadRequest("Unable to add user");
            }
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest("ID mismatch");
            }
            var updatedUser = await _userService.UpdateAsync(user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _userService.DeleteAsync(id);
            if (!result)
            {
                return NotFound("User not found");
            }
            return NoContent();
        }
    }
}
