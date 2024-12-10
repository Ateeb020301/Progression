using Progression.Dtos.Skill;
using Progression.Models;

namespace Progression.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();

        Task<Skill> GetByIdAsync(int id);
        Task<Skill> CreateAsync(Skill skillModel);
        Task<Skill?> UpdatedAsync(int id, UpdateSkillRequestDto skillDto);
        Task<Skill?> DeleteAsync(int id);


    }
}
