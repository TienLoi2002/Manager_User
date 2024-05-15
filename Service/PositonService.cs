using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Service
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public PositionDTO AddPosition(PositionDTO position)
        {
            return _positionRepository.AddPosition(position);
        }

        public bool DeletePosition(int positionId)
        {
            return _positionRepository.DeletePosition(positionId);
        }

        public List<PositionDTO> GetAllPositions()
        {
            return _positionRepository.GetAllPositions();
        }

        public PositionDTO UpdatePosition(PositionDTO position)
        {
            return _positionRepository.UpdatePosition(position);
        }
    }
}
