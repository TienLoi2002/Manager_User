using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.Model;
using Manager_User_Data;

namespace Manager_User_API.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClaimRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public ClaimDTO AddClaim(ClaimDTO claim)
        {
            var claimEntity = _mapper.Map<Claim>(claim);
            _context.Claims.Add(claimEntity);
            _context.SaveChanges();
            return _mapper.Map<ClaimDTO>(claimEntity);
        }

        public bool DeleteClaim(int claimId)
        {
            var claim = _context.Claims.Find(claimId);
            if (claim == null)
            {
                return false;
            }

            _context.Claims.Remove(claim);
            _context.SaveChanges();
            return true;
        }

        public List<ClaimDTO> GetAllClaims()
        {
            var claims = _context.Claims.ToList();
            return _mapper.Map<List<ClaimDTO>>(claims);
        }

        public ClaimDTO UpdateClaim(ClaimDTO claim)
        {
            var claimToUpdate = _context.Claims.Find(claim.ClaimId);
            if (claimToUpdate == null)
            {
                return null;
            }

            _mapper.Map(claim, claimToUpdate);
            _context.SaveChanges();
            return _mapper.Map<ClaimDTO>(claimToUpdate);
        }
    }
}
