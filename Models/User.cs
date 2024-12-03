namespace Progression.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Login(string username, string password)
        {
            // Login logic here
        }

        public void Logout()
        {
            // Logout logic here
        }
    }
}
