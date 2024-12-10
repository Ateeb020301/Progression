using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Progression.Data;
using Progression.Dtos.Goal;
using Progression.Dtos.Milestone;
using Progression.Dtos.Profile;
using Progression.Dtos.Quiz;
using Progression.Dtos.Skill;
using Progression.Interfaces;
using Progression.Mappers;
using Progression.Models;
using Progression.Repository;

namespace Progression.Controllers
{
    [Route("api/milestone")]
    [ApiController]
    public class MileStoneController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMilestoneRepository _milestoneRepository;
        private readonly IGoalRepository _goalRepository;
        public MileStoneController(ApplicationDbContext context, IMilestoneRepository milestoneRepository, IGoalRepository goalRepository)
        {
            _milestoneRepository = milestoneRepository;
            _context = context;
            _goalRepository = goalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var milstone = await _milestoneRepository.GetAllAsync();
            var stockDto = milstone.Select(s => s.ToMilestoneDto());

            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var milstone = await _milestoneRepository.GetByIdAsync(id);
            if (milstone == null)
            {
                return NotFound();
            }

            return Ok(milstone.ToMilestoneDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMilestoneRequestDto milestoneDto)
        {
            var milestoneModel = milestoneDto.ToMilestoneFromCreateDto();
            await _milestoneRepository.CreateAsync(milestoneModel);

            return CreatedAtAction(nameof(GetById), new { id = milestoneModel.Id }, milestoneModel.ToMilestoneDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMilestoneRequestDto updateDto)
        {
            var milestoneModel = await _milestoneRepository.UpdatedAsync(id, updateDto);
            if (milestoneModel == null)
            {
                return NotFound();
            }

            return Ok(milestoneModel.ToMilestoneDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var milestoneModel = await _milestoneRepository.DeleteAsync(id);

            if (milestoneModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("goal/{goalId}")]
        public async Task<IActionResult> AddMilestoneToProfile([FromRoute] int goalId, [FromBody] CreateMilestoneRequestDto milestoneDto)
        {
            //// Find the profile
            //var profile = await _context.Profile.FindAsync(profileId);
            //if (profile == null)
            //{
            //    return NotFound(new { Message = "Profile not found." });
            //}
            var goal = await _context.Goal.FindAsync(goalId);
            if (goal == null)
            {
                return NotFound(new { Message = "Goal not found." });
            }

            // Map the skill DTO to the Skill model
            var milestone = milestoneDto.ToMilestoneFromCreateDto();

            // Associate the skill with the profile
            milestone.Goal = goal;

            // Save the skill
            await _milestoneRepository.CreateAsync(milestone);

            return CreatedAtAction(nameof(GetById), new { id = milestone.Id }, milestone.ToMilestoneDto());
        }





    }
}