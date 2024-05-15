using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Service
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public ClaimDTO AddClaim(ClaimDTO claim)
        {
            return _claimRepository.AddClaim(claim);
        }

        public bool DeleteClaim(int claimId)
        {
            return _claimRepository.DeleteClaim(claimId);
        }

        public List<ClaimDTO> GetAllClaims()
        {
            return _claimRepository.GetAllClaims();
        }

        public ClaimDTO UpdateClaim(ClaimDTO claim)
        {
            return _claimRepository.UpdateClaim(claim);
        }
    }
}
