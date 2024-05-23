namespace Manager_User_API.Model
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }
        public bool IsActive => !Revoked.HasValue && !IsExpired;
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
