using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Dtos.Goal;
using Progression.Interfaces;
using Progression.Models;

namespace Progression.Repository
{
    public class GoalRepository : IGoalRepository
    {
        private readonly ApplicationDbContext _context;
        public GoalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Goal>> GetAllAsync()
        {
            return await _context.Goal
                .Include(goal => goal.Profile).Include(s => s.MilestoneList) // Include the Profile entity
                .ToListAsync();
        }

        public async Task<Goal> GetByIdAsync(int id)
        {
            //return await _context.Goal.FindAsync(id);
            return await _context.Goal.Include(s => s.MilestoneList).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Goal> CreateAsync(Goal goalModel)
        {
            await _context.Goal.AddAsync(goalModel);
            await _context.SaveChangesAsync();
            return goalModel;
        }
        public async Task<Goal> DeleteAsync(int id)
        {
            var goalModel = await _context.Goal.FirstOrDefaultAsync(x => x.Id == id);
            if (goalModel == null)
            {
                return null;
            }

            _context.Goal.Remove(goalModel);
            await _context.SaveChangesAsync();
            return goalModel;
        }

        public async Task<Goal?> UpdatedAsync(int id, UpdateGoalRequestDto goalDto)
        {
            var existingGoal = await _context.Goal.FirstOrDefaultAsync(x => x.Id == id);
            if (existingGoal == null)
            {
                return null;
            }
            existingGoal.Name = goalDto.Name;
            existingGoal.Difficulty = goalDto.Difficulty;
            //existingGoal.MilestoneList = goalDto.MilestoneList;

            await _context.SaveChangesAsync();

            return existingGoal;
        }

    }
}
