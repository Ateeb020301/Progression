using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Dtos.Goal;
using Progression.Dtos.Quiz;
using Progression.Interfaces;
using Progression.Models;

namespace Progression.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;
        public QuizRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await _context.Quiz.Include(s => s.Questions).ToListAsync();
        }

        public async Task<Quiz> GetByIdAsync(int id)
        {
            //return await _context.Quiz.FindAsync(id);
            return await _context.Quiz.Include(s => s.Questions).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Quiz> CreateAsync(Quiz quizModel)
        {
            await _context.Quiz.AddAsync(quizModel);
            await _context.SaveChangesAsync();
            return quizModel;
        }
        public async Task<Quiz> DeleteAsync(int id)
        {
            var quizModel = await _context.Quiz.FirstOrDefaultAsync(x => x.Id == id);
            if (quizModel == null)
            {
                return null;
            }

            _context.Quiz.Remove(quizModel);
            await _context.SaveChangesAsync();
            return quizModel;
        }

        public async Task<Quiz?> UpdatedAsync(int id, UpdateQuizRequestDto quizDto)
        {
            var existingQuiz = await _context.Quiz.FirstOrDefaultAsync(x => x.Id == id);
            if (existingQuiz == null)
            {
                return null;
            }
            existingQuiz.Score = quizDto.Score;
            existingQuiz.Status = quizDto.Status;
            //existingQuiz.Questions = quizDto.Questions;
            await _context.SaveChangesAsync();

            return existingQuiz;
        }

    }
}
