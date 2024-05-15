using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserRoles()
        {
            var userRoles = await _userRoleService.GetAllUserRolesAsync();
            return Ok(userRoles);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleDTO userRole)
        {
            var createdUserRole = await _userRoleService.AddUserRoleAsync(userRole);
            if (createdUserRole == null)
            {
                return BadRequest("Unable to add user role");
            }
            return CreatedAtAction(nameof(GetUserRoleById), new { userId = createdUserRole.UserId, roleId = createdUserRole.RoleId }, createdUserRole);
        }

        [HttpGet("{userId}/{roleId}")]
        public async Task<IActionResult> GetUserRoleById(int userId, int roleId)
        {
            var userRole = await _userRoleService.GetUserRoleByIdAsync(userId, roleId);
            if (userRole == null)
            {
                return NotFound();
            }
            return Ok(userRole);
        }

        [HttpPut("{userId}/{roleId}")]
        public async Task<IActionResult> UpdateUserRole(int userId, int roleId, [FromBody] UserRoleDTO userRole)
        {
            if (userId != userRole.UserId || roleId != userRole.RoleId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedUserRole = await _userRoleService.UpdateUserRoleAsync(userRole);
            if (updatedUserRole == null)
            {
                return NotFound();
            }
            return Ok(updatedUserRole);
        }

        [HttpDelete("{userId}/{roleId}")]
        public async Task<IActionResult> DeleteUserRole(int userId, int roleId)
        {
            bool result = await _userRoleService.DeleteUserRoleAsync(userId, roleId);
            if (!result)
            {
                return NotFound("User role not found");
            }
            return NoContent();
        }
    }
}
