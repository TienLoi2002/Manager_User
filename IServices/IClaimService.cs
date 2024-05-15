using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface IClaimService
    {
        List<ClaimDTO> GetAllClaims();
        ClaimDTO AddClaim(ClaimDTO claim);
        ClaimDTO UpdateClaim(ClaimDTO claim);
        bool DeleteClaim(int claimId);
    }
}
