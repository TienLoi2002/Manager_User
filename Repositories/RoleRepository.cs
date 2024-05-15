using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Manager_User_API.Model;

namespace Manager_User_API.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public RoleDTO AddRole(RoleDTO role)
        {
            var roleAdd = _mapper.Map<Role>(role);
            _context.Roles.Add(roleAdd);
            _context.SaveChanges();
            var newRoleDto = _mapper.Map<RoleDTO>(roleAdd);
            return newRoleDto;
        }

        public bool DeleteRole(int roleId)
        {
            var role = _context.Roles.Find(roleId);
            if (role == null)
            {
                return false;
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }

        public List<RoleDTO> GetAllRoles()
        {
            var roles = _context.Roles.ToList();
            return _mapper.Map<List<RoleDTO>>(roles);
        }

        public RoleDTO? UpdateRole(RoleDTO role)
        {
            var roleUpdate = _context.Roles.Find(role.RoleId);
            if (role == null)
            {
                return null;
            }

            _mapper.Map(role, roleUpdate);
            _context.SaveChanges();
            return _mapper.Map<RoleDTO>(roleUpdate);
        }
    }
}
