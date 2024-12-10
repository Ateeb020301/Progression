using Progression.Dtos.Skill;
using Progression.Models;

namespace Progression.Mappers
{
    public static class SkillMapper
    {
        public static SkillDto ToSkillDto(this Skill skillModel)
        {
            return new SkillDto
            {
                Id = skillModel.Id,
                Name = skillModel.Name,
                ProfileId = skillModel.ProfileId,
                Profile = skillModel.Profile.ToProfileNoListsDto()
            };
        }

        public static Skill ToSkillFromCreateDto(this CreateSkillRequestDto skillDto)
        {
            return new Skill
            {
                Name = skillDto.Name,
            };
        }

    }
}
