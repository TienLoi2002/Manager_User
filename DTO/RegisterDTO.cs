namespace Manager_User_API.DTO
{
    public class RegisterDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public decimal ContractSalary { get; set; }
        public int DaysOff { get; set; }
    }
}
