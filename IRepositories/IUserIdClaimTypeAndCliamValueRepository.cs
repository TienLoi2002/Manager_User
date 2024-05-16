using Manager_User_API.DTO;

namespace Manager_User_API.IRepositories
{
    public interface IUserIdClaimTypeAndCliamValueRepository
    {
        Task<List<UserIdClaimTypeAndCliamValueDTO>> GetUserClaimsAsync(string username);
    }
}
