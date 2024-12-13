using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Dtos.Profile;
using Progression.Interfaces;
using Progression.Models;

namespace Progression.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Profile>> GetAllAsync()
        {
            return await _context.Profile.Include(s => s.SkillList).Include(g => g.GoalList).ToListAsync();
        }

        public async Task<Profile> GetByIdAsync(int id)
        {
            //return await _context.Profile.FindAsync(id);
            return await _context.Profile.Include(s => s.SkillList).Include(s => s.GoalList).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Profile> CreateAsync(Profile profileModel)
        {
            await _context.Profile.AddAsync(profileModel);
            await _context.SaveChangesAsync();
            return profileModel;
        }
        public async Task<Profile> DeleteAsync(int id)
        {
            var profileModel = await _context.Profile.FirstOrDefaultAsync(x => x.Id == id);
            if (profileModel == null) {
                return null;
            }

            _context.Profile.Remove(profileModel);
            await _context.SaveChangesAsync();
            return profileModel;
        }

        public async Task<Profile?> UpdatedAsync(int id, UpdateProfileRequestDto profileDto)
        {
            var existingProfile = await _context.Profile.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProfile == null) {
                return null;
            }
            existingProfile.Name = profileDto.Name;
            existingProfile.TotalPoints = profileDto.TotalPoints;
            existingProfile.JobTitle = profileDto.JobTitle;
            //existingProfile.SkillList = profileDto.SkillList;
            //existingProfile.GoalList = profileDto.GoalList;

            await _context.SaveChangesAsync();

            return existingProfile;
        }
    }
}
