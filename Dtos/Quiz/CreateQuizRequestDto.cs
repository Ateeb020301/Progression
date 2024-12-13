

namespace Progression.Dtos.Quiz;

using Progression.Dtos.Question;
using Progression.Models;
public class CreateQuizRequestDto
    {
        public int Score { get; set; }
        public bool Status { get; set; }
        public List<CreateQuestionRequestDto> Questions { get; set; } = new List<CreateQuestionRequestDto>();
    }
