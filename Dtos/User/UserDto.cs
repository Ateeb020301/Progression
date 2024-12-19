namespace Progression.Dtos.User
{
    public class UserDto
    {
        public int Id { get; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
