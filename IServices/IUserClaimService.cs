using Manager_User_API.DTO;
using System.Collections.Generic;

namespace Manager_User_API.IServices
{
    public interface IUserClaimService
    {
        List<UserClaimDTO> GetAllUserClaims();
        UserClaimDTO AddUserClaim(UserClaimDTO userClaim);
        UserClaimDTO UpdateUserClaim(UserClaimDTO userClaim);
        bool DeleteUserClaim(int userId, int claimId);
        UserClaimDTO GetUserClaimById(int userId, int claimId);
    }
}
