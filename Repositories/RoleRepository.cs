using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Manager_User_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager_User_API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoleDTO> AddRoleAsync(RoleDTO role)
        {
            var roleAdd = _mapper.Map<Role>(role);
            await _context.Roles.AddAsync(roleAdd);
            return _mapper.Map<RoleDTO>(roleAdd);
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null)
            {
                return false;
            }

            _context.Roles.Remove(role);
            return true;
        }

        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<List<RoleDTO>>(roles);
        }

        public async Task<RoleDTO?> UpdateRoleAsync(RoleDTO role)
        {
            var roleUpdate = await _context.Roles.FindAsync(role.RoleId);
            if (roleUpdate == null)
            {
                return null;
            }

            _mapper.Map(role, roleUpdate);
            return _mapper.Map<RoleDTO>(roleUpdate);
        }
    }
}
