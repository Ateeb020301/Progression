namespace Progression.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public List<Milestone> MilestoneList { get; set; } = new List<Milestone>();

        //En til mange relasjon mellom Goal og profil
        public int ProfileId { get; set; } // Add this property
        public Profile Profile { get; set; }
    }
}
