using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Progression.Data;
using Progression.Dtos.Profile;
using Progression.Dtos.Question;
using Progression.Dtos.Quiz;
using Progression.Interfaces;
using Progression.Mappers;

namespace Progression.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IQuestionRepository _questionRepository;
        public QuestionController(ApplicationDbContext context, IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var questions = await _questionRepository.GetAllAsync();
            var stockDto = questions.Select(s => s.ToQuestionDto());

            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question.ToQuestionDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuestionRequestDto questionDto)
        {
            var questionModel = questionDto.ToQuestionFromCreateDto();
            await _questionRepository.CreateAsync(questionModel);

            return CreatedAtAction(nameof(GetById), new { id = questionModel.Id }, questionModel.ToQuestionDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateQuestionRequestDto updateDto)
        {
            var questionModel = await _questionRepository.UpdatedAsync(id, updateDto);
            if (questionModel == null)
            {
                return NotFound();
            }

            return Ok(questionModel.ToQuestionDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var questionModel = await _questionRepository.DeleteAsync(id);

            if (questionModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}
