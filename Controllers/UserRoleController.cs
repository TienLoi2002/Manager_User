using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Collections.Generic;

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
        public IActionResult GetAllUserRoles()
        {
            var userRoles = _userRoleService.GetAllUserRoles();
            return Ok(userRoles);
        }

        [HttpPost]
        public IActionResult AddUserRole([FromBody] UserRoleDTO userRole)
        {
            var createdUserRole = _userRoleService.AddUserRole(userRole);
            if (createdUserRole == null)
            {
                return BadRequest("Unable to add user role");
            }
            return CreatedAtAction(nameof(GetUserRoleById), new { id = createdUserRole.UserId }, createdUserRole);
        }

        [HttpGet("{userId}/{roleId}")]
        public IActionResult GetUserRoleById(int userId, int roleId)
        {
            var userRole = _userRoleService.GetUserRoleById(userId, roleId);
            if (userRole == null)
            {
                return NotFound();
            }
            return Ok(userRole);
        }

        [HttpPut("{userId}/{roleId}")]
        public IActionResult UpdateUserRole(int userId, int roleId, [FromBody] UserRoleDTO userRole)
        {
            if (userId != userRole.UserId || roleId != userRole.RoleId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedUserRole = _userRoleService.UpdateUserRole(userRole);
            if (updatedUserRole == null)
            {
                return NotFound();
            }
            return Ok(updatedUserRole);
        }

        [HttpDelete("{userId}/{roleId}")]
        public IActionResult DeleteUserRole(int userId, int roleId)
        {
            bool result = _userRoleService.DeleteUserRole(userId, roleId);
            if (!result)
            {
                return NotFound("User role not found");
            }
            return NoContent();
        }
    }
}
