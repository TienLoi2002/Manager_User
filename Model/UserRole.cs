﻿namespace Manager_User_API.Model
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
