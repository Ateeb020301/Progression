namespace Progression.Models
{
    public class Milestone
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

 


        //En til mange relasjon til milestone
        public int GoalId { get; set; } // Add this property
        public Goal Goal { get; set; }


        //En til mange relasjon til Quiz
        public List<Quiz>? QuizList { get; set; } = new List<Quiz>();

    }
}
