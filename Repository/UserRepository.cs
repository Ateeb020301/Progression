using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Dtos.User;
using Progression.Interfaces;
using Progression.Models;

namespace Progression.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }
        public async Task<User> DeleteAsync(int id)
        {
            var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            if (userModel == null)
            {
                return null;
            }

            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> UpdatedAsync(int id, UserDto userDto)
        {
            var existingGoal = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            if (existingGoal == null)
            {
                return null;
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            existingGoal.Email = userDto.Email;

            existingGoal.PasswordHash = passwordHash;

            await _context.SaveChangesAsync();

            return existingGoal;
        }
        public async Task<User?> GetByEmailAsync(string email) // Implementation of the new method
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
