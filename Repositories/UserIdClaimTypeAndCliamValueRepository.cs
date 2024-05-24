using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager_User_API.Repositories
{
    public class UserIdClaimTypeAndCliamValueRepository : IUserIdClaimTypeAndCliamValueRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserIdClaimTypeAndCliamValueRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<UserIdClaimTypeAndCliamValueDTO>> GetUserClaimsAsync(string username)
        {
            var userClaims = await (from uc in _context.UserClaims
                                     join u in _context.Users on uc.UserId equals u.Id
                                     join c in _context.Claims on uc.ClaimId equals c.ClaimId
                                   where u.Username == username
                                   select new UserIdClaimTypeAndCliamValueDTO
                                   {
                                       UserId = uc.UserId,
                                       ClaimType = c.ClaimType,
                                       ClaimValue = c.ClaimValue
                                   }).ToListAsync();

            return userClaims;
        }
    }
}
