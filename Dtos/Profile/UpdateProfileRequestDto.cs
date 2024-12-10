namespace Progression.Dtos.Profile;
using Progression.Models;
public class UpdateProfileRequestDto
    {
        public string Name { get; set; }
        public int TotalPoints { get; set; }
        public string JobTitle { get; set; }
        public List<Skill> SkillList { get; set; }
        public List<Goal> GoalList { get; set; }
    }
