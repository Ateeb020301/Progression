using Progression.Models;

namespace Progression.Dtos.Goal;

using Progression.Dtos.Milestone;
using Progression.Dtos.Profile;
using Progression.Models;

public class GoalNoProfileDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
}