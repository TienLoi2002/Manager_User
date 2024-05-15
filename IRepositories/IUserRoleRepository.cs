using Manager_User_API.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.IRepositories
{
    public interface IUserRoleRepository
    {
        Task<List<UserRoleDTO>> GetAllUserRolesAsync();
        Task<UserRoleDTO> AddUserRoleAsync(UserRoleDTO userRole);
        Task<UserRoleDTO> UpdateUserRoleAsync(UserRoleDTO userRole);
        Task<bool> DeleteUserRoleAsync(int userId, int roleId);
        Task<UserRoleDTO> GetUserRoleByIdAsync(int userId, int roleId);
    }
}
