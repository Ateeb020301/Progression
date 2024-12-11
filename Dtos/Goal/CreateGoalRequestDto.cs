using Progression.Models;

namespace Progression.Dtos.Goal;

using Progression.Dtos.Milestone;
using Progression.Models;

    public class CreateGoalRequestDto
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        //public List<CreateMilestoneRequestDto> MilestoneList { get; set; } = new List<CreateMilestoneRequestDto>();
    }
