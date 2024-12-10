using Progression.Dtos.Question;
using Progression.Models;
namespace Progression.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDto ToQuestionDto(this Question questionModel)
        {
            if (questionModel == null) return null;

            return new QuestionDto
            {
                Id = questionModel.Id,
                Content = questionModel.Content,
                Options = questionModel.Options,
                Answer = questionModel.Answer,
            };
        }

        public static Question ToQuestionFromCreateDto(this CreateQuestionRequestDto questionModel)
        {
            return new Question
            {
                Content = questionModel.Content,
                Options = questionModel.Options,
                Answer = questionModel.Answer,
            };
        }

    }
}