using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Progression.Data;
using Progression.Dtos.Goal;
using Progression.Dtos.Skill;
using Progression.Interfaces;
using Progression.Mappers;
using Progression.Models;
using Progression.Repository;

namespace Progression.Controllers
{
    [Route("api/goal")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGoalRepository _goalRepository;
        public GoalController(ApplicationDbContext context, IGoalRepository goalRepository)
        {

            _goalRepository = goalRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var goals = await _goalRepository.GetAllAsync();
            var stockDto = goals.Select(s => s.ToGoalDto());

            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var goal = await _goalRepository.GetByIdAsync(id);
            if (goal == null)
            {
                return NotFound();
            }

            return Ok(goal.ToGoalNoProfileDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGoalRequestDto goalDto)
        {
            var goalModel = goalDto.ToGoalFromCreateDto();
            await _goalRepository.CreateAsync(goalModel);

            return CreatedAtAction(nameof(GetById), new { id = goalModel.Id }, goalModel.ToGoalDto());

        }

        [HttpPost("profile/{profileId}")]
        public async Task<IActionResult> AddSkillToProfile([FromRoute] int profileId, [FromBody] CreateGoalRequestDto goalDto)
        {
            // Find the profile
            var profile = await _context.Profile.FindAsync(profileId);
            if (profile == null)
            {
                return NotFound(new { Message = "Profile not found." });
            }

            // Map the skill DTO to the Skill model
            var goal = goalDto.ToGoalFromCreateDto();

            // Associate the skill with the profile
            goal.Profile = profile;

            // Save the skill
            await _goalRepository.CreateAsync(goal);

            return CreatedAtAction(nameof(GetById), new { id = goal.Id }, goal.ToGoalDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGoalRequestDto updateDto)
        {
            var goalModel = await _goalRepository.UpdatedAsync(id, updateDto);
            if (goalModel == null)
            {
                return NotFound();
            }

            return Ok(goalModel.ToGoalUpdateDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var goalModel = await _goalRepository.DeleteAsync(id);

            if (goalModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}