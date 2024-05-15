using System.Collections.Generic;
using System.Threading.Tasks;
using Manager_User_API.DTO;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;

namespace Manager_User_API.Service
{
    public class ClaimService : IClaimService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClaimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClaimDTO> AddClaimAsync(ClaimDTO claim)
        {
            var addedClaim = await _unitOfWork.ClaimRepository.AddClaimAsync(claim);
            await _unitOfWork.SaveChangesAsync();
            return addedClaim;
        }

        public async Task<bool> DeleteClaimAsync(int claimId)
        {
            var result = await _unitOfWork.ClaimRepository.DeleteClaimAsync(claimId);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<List<ClaimDTO>> GetAllClaimsAsync()
        {
            return await _unitOfWork.ClaimRepository.GetAllClaimsAsync();
        }

        public async Task<ClaimDTO> UpdateClaimAsync(ClaimDTO claim)
        {
            var updatedClaim = await _unitOfWork.ClaimRepository.UpdateClaimAsync(claim);
            await _unitOfWork.SaveChangesAsync();
            return updatedClaim;
        }
    }
}
