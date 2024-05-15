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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDTO> AddAsync(UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByIdAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO user)
        {
            var userToUpdate = await _context.Users.FindAsync(user.Id);
            if (userToUpdate == null)
            {
                return null;
            }

            _mapper.Map(user, userToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(userToUpdate);
        }
    }
}
