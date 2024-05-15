using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Manager_User_API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Manager_User_API.Repositories
{
    public class UserClaimRepository : IUserClaimRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserClaimRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public UserClaimDTO AddUserClaim(UserClaimDTO userClaim)
        {
            var userClaimEntity = _mapper.Map<UserClaim>(userClaim);
            _context.UserClaims.Add(userClaimEntity);
            _context.SaveChanges();
            return _mapper.Map<UserClaimDTO>(userClaimEntity);
        }

        public bool DeleteUserClaim(int userId, int claimId)
        {
            var userClaimToDelete = _context.UserClaims
                .FirstOrDefault(uc => uc.UserId == userId && uc.ClaimId == claimId);

            if (userClaimToDelete == null)
            {
                return false;
            }

            _context.UserClaims.Remove(userClaimToDelete);
            _context.SaveChanges();

            return true;
        }

        public List<UserClaimDTO> GetAllUserClaims()
        {
            var userClaims = _context.UserClaims.ToList();
            return _mapper.Map<List<UserClaimDTO>>(userClaims);
        }

        public UserClaimDTO GetUserClaimById(int userId, int claimId)
        {
            var userClaim = _context.UserClaims
                .FirstOrDefault(uc => uc.UserId == userId && uc.ClaimId == claimId);

            return _mapper.Map<UserClaimDTO>(userClaim);
        }

        public UserClaimDTO UpdateUserClaim(UserClaimDTO userClaim)
        {
            var userClaimToUpdate = _context.UserClaims
                .FirstOrDefault(uc => uc.UserId == userClaim.UserId && uc.ClaimId == userClaim.ClaimId);

            if (userClaimToUpdate == null)
            {
                return null;
            }

            _mapper.Map(userClaim, userClaimToUpdate);
            _context.SaveChanges();
            return _mapper.Map<UserClaimDTO>(userClaimToUpdate);
        }
    }
}
