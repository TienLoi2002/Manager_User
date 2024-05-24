using Manager_User_API.DTO;

namespace Manager_User_API.IServices
{
    public interface ISalaryService
    {
        decimal CalculateSalary(UserDTO user);
    }
}
