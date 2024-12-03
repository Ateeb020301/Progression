using Progression.Models;

namespace Progression.Dtos
{
    public class UpdateProfileRequestDto
    {
        public string Name { get; set; }
        public int TotalPoints { get; set; }

        //public List<Skill> SkillList { get; set; }
        //public List<Goal> GoalList { get; set; }
    }
}
