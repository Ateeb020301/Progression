using Progression.Dtos.Profile;
using Progression.Dtos.Skill;
using Progression.Dtos.Goal;
using Progression.Models;

namespace Progression.Mappers
{
    public static class ProfileMapper
    {
        // Mapping from Profile entity to ProfileDto
        public static ProfileGoalDto ToProfileNoListsDto(this Profile profileModel)
        {
            return new ProfileGoalDto
            {
                Id = profileModel.Id,
                Name = profileModel.Name,
                TotalPoints = profileModel.TotalPoints,
                JobTitle = profileModel.JobTitle,
            };
        }

        public static UpdateProfileRequestDto ToProfileUpdateDto(this Profile profileModel)
        {
            return new UpdateProfileRequestDto
            {
                Name = profileModel.Name,
                TotalPoints = profileModel.TotalPoints,
                JobTitle = profileModel.JobTitle,
            };
        }
        public static ProfileDto ToProfileDto(this Profile profileModel)
        {
            return new ProfileDto
            {
                Id = profileModel.Id,
                Name = profileModel.Name,
                TotalPoints = profileModel.TotalPoints,
                JobTitle = profileModel.JobTitle,
                SkillList = profileModel.SkillList?.Select(s => new SkillNoProfileDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    //ProfileId = s.ProfileId
                }).ToList(),
                GoalList = profileModel.GoalList?.Select(g => new GoalNoProfileDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Difficulty = g.Difficulty,
                    //ProfileId = g.ProfileId
                }).ToList()
            };
        }
        

        // Mapping from CreateProfileRequestDto to Profile entity
        public static Profile ToProfileFromCreateDto(this CreateProfileRequestDto profileDto)
        {
            return new Profile
            {
                Name = profileDto.Name,
                TotalPoints = profileDto.TotalPoints,
                JobTitle = profileDto.JobTitle,
                SkillList = profileDto.SkillList?.Select(s => new Skill
                {
                    Name = s.Name
                }).ToList() ?? new List<Skill>(),
                GoalList = profileDto.GoalList?.Select(g => new Goal
                {
                    Name = g.Name,
                    Difficulty = g.Difficulty
                }).ToList() ?? new List<Goal>()
            };
        }
    }
}
