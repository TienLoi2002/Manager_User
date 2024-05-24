using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Manager_User_API.Controllers
{
    [Authorize]
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
        [Authorize(Policy = "get")]
        public async Task<IActionResult> GetAllUserRoles()
        {
            var userRoles = await _userRoleService.GetAllUserRolesAsync();
            return Ok(userRoles);
        }

        [HttpPost]
        [Authorize(Policy = "add")]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleDTO userRole)
        {
            var createdUserRole = await _userRoleService.AddUserRoleAsync(userRole);
            if (createdUserRole == null)
            {
                return BadRequest("Unable to add user role");
            }
            return Ok("Add success");

        }

        [HttpGet("{userId}/{roleId}")]
        [Authorize(Policy = "get")]

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
        [Authorize(Policy = "update")]
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
        [Authorize(Policy = "delete")]
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
