using Progression.Models;

namespace Progression.Dtos.Milestone
{
    public class CreateMilestoneRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool status { get; set; }
    }
}
