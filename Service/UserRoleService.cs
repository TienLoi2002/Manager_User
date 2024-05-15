using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserRoleDTO> AddUserRoleAsync(UserRoleDTO userRole)
        {
            var addedUserRole = await _unitOfWork.UserRoleRepository.AddUserRoleAsync(userRole);
            await _unitOfWork.SaveChangesAsync();
            return addedUserRole;
        }

        public async Task<bool> DeleteUserRoleAsync(int userId, int roleId)
        {
            var result = await _unitOfWork.UserRoleRepository.DeleteUserRoleAsync(userId, roleId);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<UserRoleDTO>> GetAllUserRolesAsync()
        {
            return await _unitOfWork.UserRoleRepository.GetAllUserRolesAsync();
        }

        public async Task<UserRoleDTO> GetUserRoleByIdAsync(int userId, int roleId)
        {
            return await _unitOfWork.UserRoleRepository.GetUserRoleByIdAsync(userId, roleId);
        }

        public async Task<UserRoleDTO> UpdateUserRoleAsync(UserRoleDTO userRole)
        {
            var updatedUserRole = await _unitOfWork.UserRoleRepository.UpdateUserRoleAsync(userRole);
            await _unitOfWork.SaveChangesAsync();
            return updatedUserRole;
        }
    }
}
