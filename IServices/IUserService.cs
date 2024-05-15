using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();
        UserDTO AddUser(UserDTO user);
        UserDTO UpdateUser(UserDTO user);
        bool DeleteUser(int userId);
        UserDTO GetUserById(int userId);
    }
}
