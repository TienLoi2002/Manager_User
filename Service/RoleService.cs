using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RoleDTO> AddRoleAsync(RoleDTO role)
        {
            var addedRole = await _unitOfWork.RoleRepository.AddRoleAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return addedRole;
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            var result = await _unitOfWork.RoleRepository.DeleteRoleAsync(roleId);
            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return result;
        }

        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _unitOfWork.RoleRepository.GetAllRolesAsync();
            return roles;
        }

        public async Task<RoleDTO?> UpdateRoleAsync(RoleDTO role)
        {
            var updatedRole = await _unitOfWork.RoleRepository.UpdateRoleAsync(role);
            if (updatedRole != null)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return updatedRole;
        }
    }
}
