using Manager_User_API.DTO;
using Manager_User_API.IServices;

namespace Manager_User_API.Service
{
    public class SalaryService : ISalaryService
    {
        

        public decimal CalculateSalary(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User object cannot be null.");
            }

            if (user.ContractSalary == null)
            {
                throw new ArgumentException("User's ContractSalary cannot be null.", nameof(user.ContractSalary));
            }

           

            decimal dailySalary = user.ContractSalary / 30m; // Sử dụng 30m để chia cho số nguyên
            decimal totalDeduction = dailySalary * user.DaysOff;
            decimal netSalary = user.ContractSalary - totalDeduction;

            return netSalary;
        }
    }
}
