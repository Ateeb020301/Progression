    namespace Progression.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalPoints { get; set; }

        public string JobTitle { get; set; }

        //en til mange
        public List<Skill> SkillList { get; set; } = new List<Skill>();

        //En til mange
        public List<Goal> GoalList { get; set; } = new List<Goal>();

    }
}
