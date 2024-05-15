using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Service
{
    public class UserClaimService : IUserClaimService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserClaimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserClaimDTO AddUserClaim(UserClaimDTO userClaim)
        {
            return _unitOfWork.UserClaimRepository.AddUserClaim(userClaim);
        }

        public bool DeleteUserClaim(int userId, int claimId)
        {
            return _unitOfWork.UserClaimRepository.DeleteUserClaim(userId, claimId);
        }

        public List<UserClaimDTO> GetAllUserClaims()
        {
            return _unitOfWork.UserClaimRepository.GetAllUserClaims();
        }

        public UserClaimDTO GetUserClaimById(int userId, int claimId)
        {
            return _unitOfWork.UserClaimRepository.GetUserClaimById(userId, claimId);
        }

        public UserClaimDTO UpdateUserClaim(UserClaimDTO userClaim)
        {
            return _unitOfWork.UserClaimRepository.UpdateUserClaim(userClaim);
        }
    }
}
