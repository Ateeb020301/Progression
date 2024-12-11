namespace Progression.Dtos.Quiz;
using Progression.Dtos.Question;
public class QuizDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public bool Status { get; set; }
        public int? GoalId { get; set; }
        public int? MilestoneId { get; set; }
        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
