using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Manager_User_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("get-all-role")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] RoleDTO role)
        {
            var createdRole = await _roleService.AddRoleAsync(role);
            if (createdRole == null)
            {
                return BadRequest("Unable to add role");
            }
            return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.RoleId }, createdRole);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var roles = await _roleService.GetAllRolesAsync();
            var role = roles.Find(r => r.RoleId == id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDTO role)
        {
            if (id != role.RoleId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedRole = await _roleService.UpdateRoleAsync(role);
            if (updatedRole == null)
            {
                return NotFound();
            }
            return Ok(updatedRole);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            bool result = await _roleService.DeleteRoleAsync(id);
            if (!result)
            {
                return NotFound("Role not found");
            }
            return NoContent();
        }
    }
}
