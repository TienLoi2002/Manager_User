using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;

namespace Manager_User_API.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleDTO AddRole(RoleDTO role)
        {
            return _roleRepository.AddRole(role);
        }

        public bool DeleteRole(int roleId)
        {
            return _roleRepository.DeleteRole(roleId);
        }

        public List<RoleDTO> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public RoleDTO UpdateRole(RoleDTO role)
        {
            return _roleRepository.UpdateRole(role);
        }
    }
}
