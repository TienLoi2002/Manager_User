using Manager_User_API.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.IServices
{
    public interface IPositionService
    {
        Task<List<PositionDTO>> GetAllPositionsAsync();
        Task<PositionDTO> AddPositionAsync(PositionDTO position);
        Task<PositionDTO> UpdatePositionAsync(PositionDTO position);
        Task<bool> DeletePositionAsync(int positionId);
        Task<PositionDTO> GetPositionByIdAsync(int id);
    }
}
