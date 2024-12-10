using Progression.Models;

namespace Progression.Dtos.Goal;

using Progression.Dtos.Milestone;
using Progression.Dtos.Profile;
using Progression.Models;

    public class GoalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int ProfileId { get; set; }
        public ProfileGoalDto Profile {get; set;}
        public List<MilestoneDto> MilestoneList { get; set; } = new List<MilestoneDto>();
}