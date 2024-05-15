using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface IPositionService
    {
        List<PositionDTO> GetAllPositions();
        PositionDTO AddPosition(PositionDTO position);
        PositionDTO UpdatePosition(PositionDTO position);
        bool DeletePosition(int positionId);
    }
}
