using Progression.Dtos.Milestone;
using Progression.Models;

namespace Progression.Interfaces
{
    public interface IMilestoneRepository
    {
        Task<List<Milestone>> GetAllAsync();

        Task<Milestone?> GetByIdAsync(int id);
        Task<Milestone> CreateAsync(Milestone milstoneModel);
        Task<Milestone?> UpdatedAsync(int id, UpdateMilestoneRequestDto milestoneDto);
        Task<Milestone?> DeleteAsync(int id);


    }
}
