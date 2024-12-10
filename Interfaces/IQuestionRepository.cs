using Progression.Dtos.Question;
using Progression.Models;

namespace Progression.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllAsync();

        Task<Question?> GetByIdAsync(int id);
        Task<Question> CreateAsync(Question questionModel);
        Task<Question?> UpdatedAsync(int id, UpdateQuestionRequestDto questionDto);
        Task<Question?> DeleteAsync(int id);


    }
}
