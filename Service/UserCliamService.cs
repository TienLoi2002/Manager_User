using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;

namespace Manager_User_API.Service
{
    public class UserClaimService : IUserClaimService
    {
        private readonly IUserClaimRepository _userClaimRepository;

        public UserClaimService(IUserClaimRepository userClaimRepository)
        {
            _userClaimRepository = userClaimRepository;
        }

        public UserClaimDTO AddUserClaim(UserClaimDTO userClaim)
        {
            return _userClaimRepository.AddUserClaim(userClaim);
        }

        public bool DeleteUserClaim(int userId, int claimId)
        {
            return _userClaimRepository.DeleteUserClaim(userId, claimId);
        }

        public List<UserClaimDTO> GetAllUserClaims()
        {
            return _userClaimRepository.GetAllUserClaims();
        }

        public UserClaimDTO GetUserClaimById(int userId, int claimId)
        {
            return _userClaimRepository.GetUserClaimById(userId, claimId);
        }

        public UserClaimDTO UpdateUserClaim(UserClaimDTO userClaim)
        {
            return _userClaimRepository.UpdateUserClaim(userClaim);
        }
    }
}
