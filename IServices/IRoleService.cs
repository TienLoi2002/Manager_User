using Manager_User_API.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.IServices
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO> AddRoleAsync(RoleDTO role);
        Task<RoleDTO?> UpdateRoleAsync(RoleDTO role);
        Task<bool> DeleteRoleAsync(int roleId);
    }
}
