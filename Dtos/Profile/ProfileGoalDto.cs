namespace Progression.Dtos.Profile;

using Progression.Dtos.Goal;
using Progression.Dtos.Skill;
using Progression.Models;

public class ProfileGoalDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalPoints { get; set; }
    public string JobTitle { get; set; }

}

