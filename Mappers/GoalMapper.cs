using Microsoft.CodeAnalysis.CSharp.Syntax;
using Progression.Dtos;
using Progression.Dtos.Goal;
using Progression.Dtos.Milestone;
using Progression.Dtos.Profile;
using Progression.Dtos.Question;
using Progression.Dtos.Quiz;
using Progression.Dtos.Skill;
using Progression.Models;
namespace Progression.Mappers
{
    public static class GoalMapper
    {

        public static GaolIncludeProfileIdDto ToGoalNoProfileDto(this Goal goalModel)
        {
            return new GaolIncludeProfileIdDto
            {
                Id = goalModel.Id,
                Name = goalModel.Name,
                Difficulty = goalModel.Difficulty,
                ProfileId = goalModel.ProfileId,
                //Profile = goalModel.Profile.ToProfileNoListsDto(),
                QuizList = goalModel.QuizList?.Select(s => new QuizDto
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
                }).ToList(),
                MilestoneList = goalModel.MilestoneList?.Select(s => new MilestoneDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Status = s.Status,
                    QuizList = s.QuizList?.Select(s => new QuizDto
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
                }).ToList()
            };
        }
        public static GoalDto ToGoalDto(this Goal goalModel)
        {
            return new GoalDto
            {
                Id = goalModel.Id,
                Name = goalModel.Name,
                Difficulty = goalModel.Difficulty,
                ProfileId = goalModel.ProfileId,
                Profile = goalModel.Profile.ToProfileNoListsDto(),
                MilestoneList = goalModel.MilestoneList?.Select(s => new MilestoneDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Status = s.Status
                }).ToList()
            };
        }

        public static UpdateGoalRequestDto ToGoalUpdateDto(this Goal goalModel)
        {
            return new UpdateGoalRequestDto
            {
                Name = goalModel.Name,
                Difficulty = goalModel.Difficulty,
            };
        }

        public static Goal ToGoalFromCreateDto(this CreateGoalRequestDto goalModel)
        {
            return new Goal
            {
                Name = goalModel.Name,
                Difficulty = goalModel.Difficulty,
                //MilestoneList = goalModel.MilestoneList?.Select(s => new Milestone
                //{
                //    Title = s.Title,
                //    Description = s.Description,
                //    Status = false,
                //}).ToList()
            };
        }

    }
}
