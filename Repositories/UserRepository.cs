using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Manager_User_API.Model;

namespace Manager_User_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public UserDTO AddUser(UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _context.Users.Add(userEntity);
            _context.SaveChanges();
            return _mapper.Map<UserDTO>(userEntity);
        }

        public bool DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            var userToUpdate = _context.Users.Find(user.Id);
            if (userToUpdate == null)
            {
                return null;
            }

            _mapper.Map(user, userToUpdate);
            _context.SaveChanges();
            return _mapper.Map<UserDTO>(userToUpdate);
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            return _mapper.Map<UserDTO>(user);

        }

    }
}
