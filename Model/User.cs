﻿namespace Manager_User_API.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public int PositionId { get; set; } // Foreign key
        public decimal ContractSalary { get; set; }
        public int DaysOff { get; set; } // Ngày nghỉ phép không lương

        // Navigation property để thể hiện mối quan hệ với Position
        public Position? Position { get; set; }
    }

}