using Progression.Models;

namespace Progression.Dtos
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalPoints { get; set; }
        //public List<Skill> SkillList { get; set; }
        //public List<Goal> GoalList { get; set; }
    }
}
