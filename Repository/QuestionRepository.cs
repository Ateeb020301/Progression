using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Dtos.Question;
using Progression.Dtos.Quiz;
using Progression.Interfaces;
using Progression.Models;

namespace Progression.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _context.Question.ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Question.FindAsync(id);
        }

        public async Task<Question> CreateAsync(Question quizModel)
        {
            await _context.Question.AddAsync(quizModel);
            await _context.SaveChangesAsync();
            return quizModel;
        }
        public async Task<Question> DeleteAsync(int id)
        {
            var quizModel = await _context.Question.FirstOrDefaultAsync(x => x.Id == id);
            if (quizModel == null)
            {
                return null;
            }

            _context.Question.Remove(quizModel);
            await _context.SaveChangesAsync();
            return quizModel;
        }

        public async Task<Question?> UpdatedAsync(int id, UpdateQuestionRequestDto quizDto)
        {
            var existingQuiz = await _context.Question.FirstOrDefaultAsync(x => x.Id == id);
            if (existingQuiz == null)
            {
                return null;
            }
            existingQuiz.Content = quizDto.Content;
            existingQuiz.Answer = quizDto.Answer;
            existingQuiz.Options = quizDto.Options;
            await _context.SaveChangesAsync();

            return existingQuiz;
        }

    }
}
