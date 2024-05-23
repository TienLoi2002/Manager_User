namespace Manager_User_API.Model
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
        public ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
