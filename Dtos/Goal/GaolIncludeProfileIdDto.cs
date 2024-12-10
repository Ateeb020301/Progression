using Progression.Dtos.Milestone;
using Progression.Dtos.Profile;

namespace Progression.Dtos.Goal
{
    public class GaolIncludeProfileIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int ProfileId { get; set; }
        public List<MilestoneDto> MilestoneList { get; set; } = new List<MilestoneDto>();
    }
}
