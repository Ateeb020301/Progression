namespace Progression.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public bool Status { get; set; }

        //Mange til en realsjon til Milestone
        public int? GoalId { get; set; }
        public Goal? Goal { get; set; }

        //Mange til en realsjon til Milestone
        public int? MilestoneId { get; set; }
        public Milestone? Milestone { get; set; }

        //En til mange relasjon til Questions
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
