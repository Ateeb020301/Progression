namespace Progression.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int Score { get; set; }

        //En til mange relasjon til Questions
        public List<Question> Questions { get; set; } = new List<Question>();


        //public ICollection<Question> Questions { get; set; }

        //public List<Question> GetQuestions() 
        //{
        //    return Questions;
        //}

        //public void CreateQuestion(Question question)
        //{
        //    Questions.Add(question);
        //}
    }
}
