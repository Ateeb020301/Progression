namespace Progression.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }

        //En til mange relasjon til Milestone
        public List<Milestone> MilestoneList { get; set; } = new List<Milestone>();

        //En til mange relasjon til Quiz
        public List<Quiz> QuizList { get; set; } = new List<Quiz>();

        //En til mange relasjon mellom Goal og profil
        public int ProfileId { get; set; } 
        public Profile Profile { get; set; }
    }
}
