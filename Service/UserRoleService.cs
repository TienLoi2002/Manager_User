using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;

namespace Manager_User_API.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public UserRoleDTO AddUserRole(UserRoleDTO userRole)
        {
            return _userRoleRepository.AddUserRole(userRole);
        }

        public bool DeleteUserRole(int userId, int roleId)
        {
            return _userRoleRepository.DeleteUserRole(userId, roleId);
        }

        public List<UserRoleDTO> GetAllUserRoles()
        {
            return _userRoleRepository.GetAllUserRoles();
        }

        public UserRoleDTO GetUserRoleById(int userId, int roleId)
        {
            return _userRoleRepository.GetUserRoleById(userId, roleId);
        }

        public UserRoleDTO UpdateUserRole(UserRoleDTO userRole)
        {
            return _userRoleRepository.UpdateUserRole(userRole);
        }
    }
}
