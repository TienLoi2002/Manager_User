﻿using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface IUserRoleService
    {
        List<UserRoleDTO> GetAllUserRoles();
        UserRoleDTO AddUserRole(UserRoleDTO userRole);
        UserRoleDTO UpdateUserRole(UserRoleDTO userRole);
        bool DeleteUserRole(int userId, int roleId);
        UserRoleDTO GetUserRoleById(int userId, int roleId);
    }
}