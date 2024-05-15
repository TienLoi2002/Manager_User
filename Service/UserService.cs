using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO AddUser(UserDTO user)
        {
            return _userRepository.AddUser(user);
        }

        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }

        public List<UserDTO> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            return _userRepository.UpdateUser(user);
        }

        public UserDTO GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
    }
}
