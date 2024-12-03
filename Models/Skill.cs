namespace Progression.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Profile Profile { get; set; }

        //public void RegisterSkill(string name, List<Skill> skills, Goal goal)
        //{
        //    Name = name;
        //    skills.Add(this);
        //}
    }
}
