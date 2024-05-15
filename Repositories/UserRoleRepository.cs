using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Manager_User_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRoleRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<UserRoleDTO> AddUserRoleAsync(UserRoleDTO userRole)
        {
            var userRoleEntity = _mapper.Map<UserRole>(userRole);
            _context.UserRoles.Add(userRoleEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserRoleDTO>(userRoleEntity);
        }

        public async Task<bool> DeleteUserRoleAsync(int userId, int roleId)
        {
            var userRoleToDelete = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRoleToDelete == null)
            {
                return false;
            }

            _context.UserRoles.Remove(userRoleToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<UserRoleDTO>> GetAllUserRolesAsync()
        {
            var userRoles = await _context.UserRoles.ToListAsync();
            return _mapper.Map<List<UserRoleDTO>>(userRoles);
        }

        public async Task<UserRoleDTO> GetUserRoleByIdAsync(int userId, int roleId)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public async Task<UserRoleDTO> UpdateUserRoleAsync(UserRoleDTO userRole)
        {
            var userRoleToUpdate = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userRole.UserId && ur.RoleId == userRole.RoleId);

            if (userRoleToUpdate == null)
            {
                return null;
            }

            _mapper.Map(userRole, userRoleToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserRoleDTO>(userRoleToUpdate);
        }
    }
}
