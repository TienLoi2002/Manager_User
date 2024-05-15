using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface IRoleService
    {
        List<RoleDTO> GetAllRoles();
        RoleDTO AddRole(RoleDTO role);
        RoleDTO UpdateRole(RoleDTO role);
        bool DeleteRole(int roleId);
    }
}
