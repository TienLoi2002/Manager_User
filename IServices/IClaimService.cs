using System.Collections.Generic;
using System.Threading.Tasks;
using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface IClaimService
    {
        Task<List<ClaimDTO>> GetAllClaimsAsync();
        Task<ClaimDTO> AddClaimAsync(ClaimDTO claim);
        Task<ClaimDTO> UpdateClaimAsync(ClaimDTO claim);
        Task<bool> DeleteClaimAsync(int claimId);
    }
}
