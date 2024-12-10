using Progression.Dtos.Profile;
using Progression.Dtos.Quiz;
using Progression.Models;

namespace Progression.Interfaces
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetAllAsync();

        Task<Quiz?> GetByIdAsync(int id);
        Task<Quiz> CreateAsync(Quiz quizModel);
        Task<Quiz?> UpdatedAsync(int id, UpdateQuizRequestDto quizDto);
        Task<Quiz?> DeleteAsync(int id);
    }
}
