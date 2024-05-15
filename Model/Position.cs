namespace Manager_User_API.Model
{
    public class Position
    {
        public int PositionId { get; set; }
        public string? PositionName { get; set; }

        public ICollection<User>? Users { get; set; }
    }

}
