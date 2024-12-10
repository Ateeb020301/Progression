using Progression.Dtos.Milestone;
using Progression.Dtos.Quiz;
using Progression.Dtos.Question;
using Progression.Models;

namespace Progression.Mappers
{
    public static class MilestoneMapper
    {
        public static MilestoneDto ToMilestoneDto(this Milestone milestoneModel)
        {
            return new MilestoneDto
            {
                Id = milestoneModel.Id,
                Title = milestoneModel.Title,
                Description = milestoneModel.Description,
                Status = milestoneModel.Status,
                QuizList = milestoneModel.QuizList?.Select(s => new QuizDto
                {
                    Id = s.Id,
                    Score = s.Score,
                    Status = s.Status,
                    Questions = s.Questions?.Select(q => new QuestionDto
                    {
                        Id = q.Id,
                        Content = q.Content,
                        Options = q.Options,
                        Answer = q.Answer
                    }).ToList()
                }).ToList()
            };
        }

        public static Milestone ToMilestoneFromCreateDto(this CreateMilestoneRequestDto milestoneDto)
        {
            return new Milestone
            {
                Title = milestoneDto.Title,
                Description = milestoneDto.Description,
                Status = milestoneDto.status

            };
        }

    }
}
