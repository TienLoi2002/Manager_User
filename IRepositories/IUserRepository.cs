using Manager_User_API.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.IRepositories
{
    public interface IUserRepository
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO> AddAsync(UserDTO user);
        Task<UserDTO> UpdateAsync(UserDTO user);
        Task<bool> DeleteAsync(int userId);
        Task<UserDTO> GetByIdAsync(int userId);
    }
}
