namespace Manager_User_API.Model
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
