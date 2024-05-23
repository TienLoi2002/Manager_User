using Manager_User_API.Model;

namespace Manager_User_API.IRepositories
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);
        Task<RefreshToken> GetByTokenAsync(string token);
        Task UpdateAsync(RefreshToken refreshToken);
    }
}