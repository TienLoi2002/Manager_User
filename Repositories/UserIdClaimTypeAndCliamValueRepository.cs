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
            var userClaims = await (from u in _context.Users 
                                     join ur in _context.UserRoles on u.Id equals ur.UserId
                                     join r in _context.Roles on ur.RoleId equals r.RoleId
                                     join rc in _context.RoleClaims on r.RoleId equals rc.RoleId
                                     join c in _context.Claims on rc.ClaimId equals c.ClaimId
                                   where u.Username == username
                                   select new UserIdClaimTypeAndCliamValueDTO
                                   {
                                       UserId = u.Id,
                                       ClaimType = c.ClaimType,
                                       ClaimValue = c.ClaimValue
                                   }).ToListAsync();

            return userClaims;
        }
    }
}
