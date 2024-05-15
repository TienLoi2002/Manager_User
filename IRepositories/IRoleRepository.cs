using Manager_User_API.DTO;

namespace Manager_User_API.IRepositories
{
    public interface IRoleRepository
    {
        List<RoleDTO> GetAllRoles();
        RoleDTO AddRole(RoleDTO role);
        RoleDTO UpdateRole(RoleDTO role);
        bool DeleteRole(int roleId);

    }
}
