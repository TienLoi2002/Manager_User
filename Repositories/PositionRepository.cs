using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_Data;
using Manager_User_API.Model;

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

        public PositionDTO AddPosition(PositionDTO position)
        {
            var positionEntity = _mapper.Map<Position>(position);
            _context.Positions.Add(positionEntity);
            _context.SaveChanges();
            return _mapper.Map<PositionDTO>(positionEntity);
        }

        public bool DeletePosition(int positionId)
        {
            var position = _context.Positions.Find(positionId);
            if (position == null)
            {
                return false;
            }

            _context.Positions.Remove(position);
            _context.SaveChanges();
            return true;
        }

        public List<PositionDTO> GetAllPositions()
        {
            var positions = _context.Positions.ToList();
            return _mapper.Map<List<PositionDTO>>(positions);
        }

        public PositionDTO UpdatePosition(PositionDTO position)
        {
            var positionToUpdate = _context.Positions.Find(position.PositionId);
            if (positionToUpdate == null)
            {
                return null;
            }

            _mapper.Map(position, positionToUpdate);
            _context.SaveChanges();
            return _mapper.Map<PositionDTO>(positionToUpdate);
        }
    }
}
