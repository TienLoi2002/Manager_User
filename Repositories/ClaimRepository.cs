
using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.Model;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ClaimDTO> AddClaimAsync(ClaimDTO claim)
        {
            var claimEntity = _mapper.Map<Claim>(claim);
            _context.Claims.Add(claimEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClaimDTO>(claimEntity);
        }

        public async Task<bool> DeleteClaimAsync(int claimId)
        {
            var claim = await _context.Claims.FindAsync(claimId);
            if (claim == null)
            {
                return false;
            }

            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ClaimDTO>> GetAllClaimsAsync()
        {
            var claims = await _context.Claims.ToListAsync();
            return _mapper.Map<List<ClaimDTO>>(claims);
        }

        public async Task<ClaimDTO> UpdateClaimAsync(ClaimDTO claim)
        {
            var claimToUpdate = await _context.Claims.FindAsync(claim.ClaimId);
            if (claimToUpdate == null)
            {
                return null;
            }

            _mapper.Map(claim, claimToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClaimDTO>(claimToUpdate);
        }
    }
}
