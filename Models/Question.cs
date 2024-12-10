namespace Progression.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public int Answer { get; set; }

        //Mange til en relasjon til Quiz
        public int QuizId { get; set; } // Add this property
        public Quiz Quiz { get; set; }
    }  
}
