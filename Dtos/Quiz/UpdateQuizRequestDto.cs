namespace Progression.Dtos.Quiz;
using Progression.Models;
public class UpdateQuizRequestDto
    {
        public int Score { get; set; }
        public bool Status { get; set; }
        //public List<Question> Questions { get; set; } = new List<Question>();
    }
