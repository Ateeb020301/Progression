using Progression.Dtos;
using Progression.Dtos.Goal;
using Progression.Models;

namespace Progression.Interfaces
{
    public interface IGoalRepository
    {
        Task<List<Goal>> GetAllAsync();

        Task<Goal?> GetByIdAsync(int id);
        Task<Goal> CreateAsync(Goal goalModel);
        Task<Goal?> UpdatedAsync(int id, UpdateGoalRequestDto goalDto);
        Task<Goal?> DeleteAsync(int id);


    }
}
