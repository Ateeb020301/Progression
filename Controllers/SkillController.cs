using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Progression.Data;
using Progression.Dtos.Skill;
using Progression.Interfaces;
using Progression.Mappers;

namespace Progression.Controllers
{
    [Route("api/skill")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISkillRepository _skillRepository;
        public SkillController(ApplicationDbContext context, ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _skillRepository.GetAllAsync();
            var stockDto = skills.Select(s => s.ToSkillDto());

            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill.ToSkillDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSkillRequestDto skillDto)
        {
            var skillModel = skillDto.ToSkillFromCreateDto();
            await _skillRepository.CreateAsync(skillModel);

            return CreatedAtAction(nameof(GetById), new { id = skillModel.Id }, skillModel.ToSkillDto());

        }

        [HttpPost("profile/{profileId}")]
        public async Task<IActionResult> AddSkillToProfile([FromRoute] int profileId, [FromBody] CreateSkillRequestDto skillDto)
        {
            // Find the profile
            var profile = await _context.Profile.FindAsync(profileId);
            if (profile == null)
            {
                return NotFound(new { Message = "Profile not found." });
            }

            // Map the skill DTO to the Skill model
            var skill = skillDto.ToSkillFromCreateDto();

            // Associate the skill with the profile
            skill.Profile = profile;

            // Save the skill
            await _skillRepository.CreateAsync(skill);

            return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill.ToSkillDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSkillRequestDto updateDto)
        {
            var skillModel = await _skillRepository.UpdatedAsync(id, updateDto);
            if (skillModel == null)
            {
                return NotFound();
            }

            return Ok(skillModel.ToSkillDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var skillModel = await _skillRepository.DeleteAsync(id);

            if (skillModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}