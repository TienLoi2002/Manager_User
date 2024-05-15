using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Manager_User_API.Model;

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

        public UserRoleDTO AddUserRole(UserRoleDTO userRole)
        {
            var userRoleEntity = _mapper.Map<UserRole>(userRole);
            _context.UserRoles.Add(userRoleEntity);
            _context.SaveChanges();
            return _mapper.Map<UserRoleDTO>(userRoleEntity);
        }

        public bool DeleteUserRole(int userId, int roleId)
        {
            var userRoleToDelete = _context.UserRoles
                .FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRoleToDelete == null)
            {
                return false;
            }

            _context.UserRoles.Remove(userRoleToDelete);
            _context.SaveChanges();

            return true;
        }

        public List<UserRoleDTO> GetAllUserRoles()
        {
            var userRoles = _context.UserRoles.ToList();
            return _mapper.Map<List<UserRoleDTO>>(userRoles);
        }

        public UserRoleDTO GetUserRoleById(int userId, int roleId)
        {
            var userRole = _context.UserRoles
                .FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);

            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public UserRoleDTO UpdateUserRole(UserRoleDTO userRole)
        {
            var userRoleToUpdate = _context.UserRoles
                .FirstOrDefault(ur => ur.UserId == userRole.UserId && ur.RoleId == userRole.RoleId);

            if (userRoleToUpdate == null)
            {
                return null;
            }

            _mapper.Map(userRole, userRoleToUpdate);
            _context.SaveChanges();
            return _mapper.Map<UserRoleDTO>(userRoleToUpdate);
        }
    }
}
