using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Progression.Data;
using Progression.Dtos.Profile;
using Progression.Interfaces;
using Progression.Mappers;

namespace Progression.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProfileRepository _profileRepository;
        public ProfileController(ApplicationDbContext context, IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profiles = await _profileRepository.GetAllAsync();
            var stockDto = profiles.Select(s => s.ToProfileDto());

            return  Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var profile = await _profileRepository.GetByIdAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile.ToProfileDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfileRequestDto profileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var profileModel = profileDto.ToProfileFromCreateDto();
            await _profileRepository.CreateAsync(profileModel);

            return CreatedAtAction(nameof(GetById), new { id = profileModel.Id }, profileModel.ToProfileDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProfileRequestDto updateDto)
        {
            var profileModel = await _profileRepository.UpdatedAsync(id, updateDto);
            if (profileModel == null)
            {
                return NotFound();
            }

            return Ok(profileModel.ToProfileDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var profileModel = await _profileRepository.DeleteAsync(id);

            if(profileModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

       

    }
}
