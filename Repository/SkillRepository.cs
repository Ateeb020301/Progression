using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Dtos.Skill;
using Progression.Interfaces;
using Progression.Models;

namespace Progression.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;
        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _context.Skill.Include(s => s.Profile).ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _context.Skill.FindAsync(id);
        }

        public async Task<Skill> CreateAsync(Skill skillModel)
        {
            await _context.Skill.AddAsync(skillModel);
            await _context.SaveChangesAsync();
            return skillModel;
        }
        public async Task<Skill> DeleteAsync(int id)
        {
            var skillModel = await _context.Skill.FirstOrDefaultAsync(x => x.Id == id);
            if (skillModel == null)
            {
                return null;
            }

            _context.Skill.Remove(skillModel);
            await _context.SaveChangesAsync();
            return skillModel;
        }

        public async Task<Skill?> UpdatedAsync(int id, UpdateSkillRequestDto skillDto)
        {
            var existingSkill = await _context.Skill.FirstOrDefaultAsync(x => x.Id == id);
            if (existingSkill == null)
            {
                return null;
            }
            existingSkill.Name = skillDto.Name;


            await _context.SaveChangesAsync();

            return existingSkill;
        }
    }
}
