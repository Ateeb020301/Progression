using Progression.Models;

namespace Progression.Dtos.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Answer { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }
}
