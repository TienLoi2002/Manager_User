using Manager_User_API.Enum;

namespace Manager_User_API.Model
{
    public class Form
    {
        public int FormId { get; set; }
        public int UserId { get; set; }
        public string? FilePath { get; set; }
        public DateTime DateSubmitted { get; set; }
        public FormType Type { get; set; }

        public User? User { get; set; }
    }


}
