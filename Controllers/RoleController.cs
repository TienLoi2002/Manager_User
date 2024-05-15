using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("/api/[controller]/get-all-role")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpPost]
        [Route("/api/[controller]/add-role")]

        public IActionResult AddRole([FromBody] RoleDTO role)
        {
            var createdRole = _roleService.AddRole(role);
            if (createdRole == null)
            {
                return BadRequest("Unable to add role");
            }
            return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.RoleId }, createdRole);
        }

        [HttpGet("{id}")]

        public IActionResult GetRoleById(int id)
        {
            var role = _roleService.GetAllRoles().Find(r => r.RoleId == id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateRole(int id, [FromBody] RoleDTO role)
        {
            if (id != role.RoleId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedRole = _roleService.UpdateRole(role);
            if (updatedRole == null)
            {
                return NotFound();
            }
            return Ok(updatedRole);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteRole(int id)
        {
            bool result = _roleService.DeleteRole(id);
            if (!result)
            {
                return NotFound("Role not found");
            }
            return NoContent();
        }
    }
}
