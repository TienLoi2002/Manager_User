using Manager_User_API.DTO;
using Manager_User_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Manager_User_API.IRepositories
{
    public interface IUserRepository
    {
        List<UserDTO> GetAllUsers();
        UserDTO AddUser(UserDTO user);
        UserDTO UpdateUser(UserDTO user);
        bool DeleteUser(int userId);
        UserDTO GetUserById(int userId);
        
    }
}
