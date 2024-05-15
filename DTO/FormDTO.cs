using Manager_User_API.Enum;
using Manager_User_API.Model;

namespace Manager_User_API.DTO
{
    public class FormDTO
    {
        public int FormId { get; set; }
        public int UserId { get; set; }
        public string? FilePath { get; set; }
        public DateTime DateSubmitted { get; set; }
        public FormType Type { get; set; }
    }
}
