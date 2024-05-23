using Manager_User_API.Model;

namespace Manager_User_API.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public int PositionId { get; set; } // Foreign key
        public decimal ContractSalary { get; set; }
        public int DaysOff { get; set; } // Ngày nghỉ phép không lương

        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
