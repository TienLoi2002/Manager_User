using Manager_User_API.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.IServices
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO> AddAsync(UserDTO user);
        Task<UserDTO> UpdateAsync(UserDTO user);
        Task<bool> DeleteAsync(int userId);
        Task<UserDTO> GetByIdAsync(int userId);

        Task<UserDTO> AuthenticateAsync(string username, string password);
        Task RegisterAsync(RegisterDTO registerDto);
    }
}
