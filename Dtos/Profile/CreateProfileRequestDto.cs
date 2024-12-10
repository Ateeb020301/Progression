namespace Progression.Dtos.Profile;

using Progression.Dtos.Goal;
using Progression.Dtos.Skill;
using Progression.Models;

    public class CreateProfileRequestDto
    {

        public string Name { get; set; }
        public int TotalPoints { get; set; }
        public string JobTitle { get; set; }

        public List<CreateSkillRequestDto> SkillList { get; set; }
        public List<CreateGoalRequestDto> GoalList { get; set; }
    }
