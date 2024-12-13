using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Progression.Data;
using Progression.Dtos.Profile;
using Progression.Dtos.Quiz;
using Progression.Interfaces;
using Progression.Mappers;
using Progression.Models;
using Progression.Repository;

namespace Progression.Controllers
{
    [Route("api/quizq")]
    [ApiController]
    public class QuizQController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IQuizRepository _quizRepository;
        public QuizQController(ApplicationDbContext context, IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quizes = await _quizRepository.GetAllAsync();
            var stockDto = quizes.Select(s => s.ToQuizDto());

            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var quiz = await _quizRepository.GetByIdAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz.ToQuizDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuizRequestDto quizDto)
        {
            var quizModel = quizDto.ToQuizFromCreateDto();
            await _quizRepository.CreateAsync(quizModel);

            return CreatedAtAction(nameof(GetById), new { id = quizModel.Id }, quizModel.ToQuizDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateQuizRequestDto updateDto)
        {
            var quizModel = await _quizRepository.UpdatedAsync(id, updateDto);
            if (quizModel == null)
            {
                return NotFound();
            }

            return Ok(quizModel.ToQuizUpdateDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var quizModel = await _quizRepository.DeleteAsync(id);

            if (quizModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost("milestone/{milestoneId}")]
        public async Task<IActionResult> AddQuizToMilestone([FromRoute] int milestoneId, [FromBody] CreateQuizRequestDto quizDto)
        {
            // Find the milestone
            var milestone = await _context.Milestone.FindAsync(milestoneId);
            if (milestone == null)
            {
                return NotFound(new { Message = "Milestone not found." });
            }

            // Map the skill DTO to the Quiz model
            var quiz = quizDto.ToQuizFromCreateDto();

            // Associate the quiz with the milestone
            quiz.Milestone = milestone;

            // Save the skill
            await _quizRepository.CreateAsync(quiz);
            return CreatedAtAction(nameof(GetById), new { id = quiz.Id }, quiz.ToQuizDto());
        }

        [HttpPost("goal/{goalId}")]
        public async Task<IActionResult> AddQuizToGoal([FromRoute] int goalId, [FromBody] CreateQuizRequestDto quizDto)
        {
            // Find the goal
            var goal = await _context.Goal.FindAsync(goalId);
            if (goal == null)
            {
                return NotFound(new { Message = "Milestone not found." });
            }

            // Map the goal DTO to the Quiz model
            var quiz = quizDto.ToQuizFromCreateDto();

            // Associate the quiz with the milestone
            quiz.Goal = goal;

            // Save the skill
            await _quizRepository.CreateAsync(quiz);
            return CreatedAtAction(nameof(GetById), new { id = quiz.Id }, quiz.ToQuizDto());
        }


    }
}
