using Progression.Models;

namespace Progression.Dtos.Goal;

using Progression.Dtos.Milestone;
using Progression.Models;
    public class UpdateGoalRequestDto
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public List<MilestoneDto> MilestoneList { get; set; } = new List<MilestoneDto>();
    }
