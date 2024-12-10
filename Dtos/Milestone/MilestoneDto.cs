

namespace Progression.Dtos.Milestone;

using Progression.Dtos.Quiz;
using Progression.Models;
public class MilestoneDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        //En til mange relasjon til Questions
        public List<QuizDto> QuizList { get; set; } = new List<QuizDto>();
    }
