using Progression.Dtos.User;
using Progression.Models;

namespace Progression.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdatedAsync(int id, UserDto userDto);
        Task<User?> DeleteAsync(int id);
        Task<User?> GetByEmailAsync(string email); // New method to retrieve user by email
    }
}
