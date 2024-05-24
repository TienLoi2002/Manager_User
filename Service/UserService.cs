using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using Manager_User_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TokenHelper _tokenHelper;
        private readonly ISalaryService _salaryService;
        

        public UserService(IUnitOfWork unitOfWork, TokenHelper tokenHelper, ISalaryService salaryService)
        {
            _unitOfWork = unitOfWork;
            _tokenHelper = tokenHelper;
            _salaryService = salaryService;
        }

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

        public async Task SaveRefreshTokenAsync(string username, string refreshToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
            var tokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };

            await _unitOfWork.RefreshTokensRepository.AddAsync(tokenEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<AuthenticationResponse> RefreshTokenAsync(string token, string refreshToken)
        {
            var principal = _tokenHelper.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;

            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
            if (user == null || !user.RefreshTokens.Any(rt => rt.Token == refreshToken && rt.IsActive))
            {
                return null;
            }

            var refreshTokenEntity = user.RefreshTokens.Single(rt => rt.Token == refreshToken);

            refreshTokenEntity.Revoked = DateTime.UtcNow;

            var newJwtToken = await _tokenHelper.GenerateTokenAsync(user.Username);
            var newRefreshToken = _tokenHelper.GenerateRefreshToken();

            user.RefreshTokens.Add(newRefreshToken);
            await _unitOfWork.SaveChangesAsync();

            return new AuthenticationResponse
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken.Token
            };
        }

        public async Task<decimal> GetUserSalaryAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            return _salaryService.CalculateSalary(user);
        }


    }
}
