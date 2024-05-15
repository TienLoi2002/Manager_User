using Manager_User_API.IRepositories;
using Manager_User_Data;

namespace Manager_User_API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRoleRepository RoleRepository { get; private set; }
        public IClaimRepository ClaimRepository { get; private set; }
        public IFormRepository FormRepository { get; private set; }
        public IPositionRepository PositionRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public IUserClaimRepository UserClaimRepository { get; private set; }
        public IUserRoleRepository UserRoleRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context, IRoleRepository roleRepository, IClaimRepository claimRepository, IFormRepository formRepository, IPositionRepository positionRepository, IUserRepository userRepository , IUserClaimRepository userClaimRepository, IUserRoleRepository userRoleRepository)
        {
            _context = context;
            RoleRepository = roleRepository;
            ClaimRepository = claimRepository;
            FormRepository = formRepository;
            PositionRepository = positionRepository;
            UserRepository = userRepository;
            UserClaimRepository = userClaimRepository;
            UserRoleRepository = userRoleRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
