using System;
using System.Threading.Tasks;

namespace Manager_User_API.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository RoleRepository { get; }
        IClaimRepository ClaimRepository { get; }
        IFormRepository FormRepository { get; }
        IPositionRepository PositionRepository { get; }
        IUserRepository UserRepository { get; }
        IUserClaimRepository UserClaimRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IRefreshTokenRepository RefreshTokensRepository { get; }
        

        Task<int> SaveChangesAsync();
    }
}
