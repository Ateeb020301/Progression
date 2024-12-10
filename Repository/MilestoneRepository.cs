using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Dtos.Milestone;
using Progression.Interfaces;
using Progression.Models;

namespace Progression.Repository
{
    public class MilestoneRepository : IMilestoneRepository
    {
        private readonly ApplicationDbContext _context;
        public MilestoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Milestone>> GetAllAsync()
        {
            return await _context.Milestone.Include(s => s.QuizList).ToListAsync();
        }

        public async Task<Milestone> GetByIdAsync(int id)
        {
            return await _context.Milestone.Include(s => s.QuizList).ThenInclude( p => p.Questions).FirstOrDefaultAsync(s => s.Id == id );
      
        }

        public async Task<Milestone> CreateAsync(Milestone milestoneModel)
        {
            await _context.Milestone.AddAsync(milestoneModel);
            await _context.SaveChangesAsync();
            return milestoneModel;
        }
        public async Task<Milestone> DeleteAsync(int id)
        {
            var milestoneModel = await _context.Milestone.FirstOrDefaultAsync(x => x.Id == id);
            if (milestoneModel == null)
            {
                return null;
            }

            _context.Milestone.Remove(milestoneModel);
            await _context.SaveChangesAsync();
            return milestoneModel;
        }

        public async Task<Milestone?> UpdatedAsync(int id, UpdateMilestoneRequestDto milestoneDto)
        {
            var existingMilestone = await _context.Milestone.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMilestone == null)
            {
                return null;
            }
            existingMilestone.Title = milestoneDto.Title;
            existingMilestone.Description = milestoneDto.Description;
            //existingMilestone.Status = milestoneDto.Status;

            await _context.SaveChangesAsync();

            return existingMilestone;
        }
    }
}
