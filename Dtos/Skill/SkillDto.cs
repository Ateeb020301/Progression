using Progression.Dtos.Profile;




namespace Progression.Dtos.Skill;
using Progression.Models;
public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfileId { get; set; }

        public ProfileGoalDto Profile { get; set; }
    }
