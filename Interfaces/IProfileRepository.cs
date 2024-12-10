using Progression.Dtos.Profile;
using Progression.Models;

namespace Progression.Interfaces
{
    public interface IProfileRepository
    {
        Task<List<Profile>> GetAllAsync();

        Task<Profile?> GetByIdAsync(int id);
        Task<Profile> CreateAsync(Profile profileModel);
        Task<Profile?> UpdatedAsync(int id, UpdateProfileRequestDto profileDto);
        Task<Profile?> DeleteAsync(int id);


    }
}
