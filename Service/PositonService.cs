using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Service
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PositionDTO> AddPositionAsync(PositionDTO position)
        {
            var addedPosition = await _unitOfWork.PositionRepository.AddPositionAsync(position);
            await _unitOfWork.SaveChangesAsync();
            return addedPosition;
        }

        public async Task<bool> DeletePositionAsync(int positionId)
        {
            var result = await _unitOfWork.PositionRepository.DeletePositionAsync(positionId);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<PositionDTO>> GetAllPositionsAsync()
        {
            return await _unitOfWork.PositionRepository.GetAllPositionsAsync();
        }

        public async Task<PositionDTO> UpdatePositionAsync(PositionDTO position)
        {
            var updatedPosition = await _unitOfWork.PositionRepository.UpdatePositionAsync(position);
            await _unitOfWork.SaveChangesAsync();
            return updatedPosition;
        }

        public async Task<PositionDTO> GetPositionByIdAsync(int id)
        {
            return await _unitOfWork.PositionRepository.GetPositionByIdAsync(id);
        }
    }
}
