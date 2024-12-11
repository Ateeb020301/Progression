using Progression.Dtos.Question;
using Progression.Dtos.Quiz;
using Progression.Models;
namespace Progression.Mappers
{
   public static class QuizMapper
{
    public static QuizDto ToQuizDto(this Quiz quizModel)
    {
        return new QuizDto
        {
            Id = quizModel.Id,
            Score = quizModel.Score,
            Status = quizModel.Status,
            MilestoneId = quizModel.MilestoneId,
            GoalId = quizModel.GoalId,
            Questions = quizModel.Questions?.Select(q => new QuestionDto
            {
                Id = q.Id,
                Content = q.Content,
                Options = q.Options,
                Answer = q.Answer
            }).ToList()
        };
    }

    public static Quiz ToQuizFromCreateDto(this CreateQuizRequestDto quizDto)
    {
        return new Quiz
        {
            Score = quizDto.Score,
            Status = quizDto.Status,
            Questions = quizDto.Questions?.Select(q => new Question
            {
                Content = q.Content,
                Answer = q.Answer,
                Options = q.Options.ToList()
            }).ToList()
        };
    }
}

}
