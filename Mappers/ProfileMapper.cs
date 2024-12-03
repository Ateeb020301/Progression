using Microsoft.CodeAnalysis.CSharp.Syntax;
using Progression.Dtos;

namespace Progression.Mappers
{
    public static class ProfileMapper
    {
        public static ProfileDto ToProfileDto(this Models.Profile profileModel)
        {
            return new ProfileDto
            {
                Id = profileModel.Id,
                Name = profileModel.Name,
                TotalPoints = profileModel.TotalPoints,
                //SkillList = profileModel.SkillList,
                //GoalList = profileModel.GoalList,
            };
        }

        public static Models.Profile ToProfileFromCreateDto(this CreateProfileRequestDto profileDto)
        {
            return new Models.Profile
            {
                Name = profileDto.Name,
                TotalPoints = profileDto.TotalPoints,
                //SkillList = profileDto.SkillList,
                //GoalList = profileDto.GoalList,
            };
        }

    }
}
