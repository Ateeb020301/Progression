using Progression.Dtos;
using Progression.Models;

namespace Progression.Interfaces
{
    public interface IProfileRepository
    {
        Task<List<Models.Profile>> GetAllAsync();

        Task<Models.Profile?> GetByIdAsync(int id);
        Task<Models.Profile> CreateAsync(Profile profileModel);
        Task<Models.Profile?> UpdatedAsync(int id, UpdateProfileRequestDto profileDto);
        Task<Models.Profile?> DeleteAsync(int id);


    }
}
