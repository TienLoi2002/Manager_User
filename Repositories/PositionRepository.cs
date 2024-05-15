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
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PositionRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<PositionDTO> AddPositionAsync(PositionDTO position)
        {
            var positionEntity = _mapper.Map<Position>(position);
            _context.Positions.Add(positionEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PositionDTO>(positionEntity);
        }

        public async Task<bool> DeletePositionAsync(int positionId)
        {
            var position = await _context.Positions.FindAsync(positionId);
            if (position == null)
            {
                return false;
            }

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PositionDTO>> GetAllPositionsAsync()
        {
            var positions = await _context.Positions.ToListAsync();
            return _mapper.Map<List<PositionDTO>>(positions);
        }

        public async Task<PositionDTO> UpdatePositionAsync(PositionDTO position)
        {
            var positionToUpdate = await _context.Positions.FindAsync(position.PositionId);
            if (positionToUpdate == null)
            {
                return null;
            }

            _mapper.Map(position, positionToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<PositionDTO>(positionToUpdate);
        }
        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            return _mapper.Map<PositionDTO>(position);
        }
    }
}
