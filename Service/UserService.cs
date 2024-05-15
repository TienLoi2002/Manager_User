using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task<UserDTO> AuthenticateAsync(string username, string password)
        {
            var userDto = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
            if (userDto == null || userDto.Password != password)
            {
                return null;
            }
            return userDto;
        }


        public async Task RegisterAsync(RegisterDTO registerDto)
        {
            var user = new UserDTO
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
                PhoneNumber = registerDto.PhoneNumber,
                PositionId = registerDto.PositionId,
                ContractSalary = registerDto.ContractSalary,
                DaysOff = registerDto.DaysOff
            };

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> AddAsync(UserDTO user)
        {
            var addedUser = await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return addedUser;
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var result = await _unitOfWork.UserRepository.DeleteAsync(userId);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<UserDTO> GetByIdAsync(int userId)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(userId);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO user)
        {
            var updatedUser = await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return updatedUser;
        }
    }
}
