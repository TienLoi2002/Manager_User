using Manager_User_API.DTO;

namespace Manager_User_API.IRepositories
{
    public interface IClaimRepository
    {
        List<ClaimDTO> GetAllClaims();
        ClaimDTO AddClaim(ClaimDTO claim);
        ClaimDTO UpdateClaim(ClaimDTO claim);
        bool DeleteClaim(int claimId);

    }
}
