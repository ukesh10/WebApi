using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        // Get Walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomain = await walkRepository.GetAllAsync();
            // Convert Domain to DTO and return DTO
            return Ok(mapper.Map<List<WalkDTO>>(walksDomain));
        }

        // Get Walk by Id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.GetByIdAsync(id);
            if (walkDomain == null) { return NotFound(); }
            //Convert Domain to DTO
            var walkDto = mapper.Map<WalkDTO>(walkDomain);
            return Ok(walkDto);
        }

        // Create Walk
        // POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to Domain Model
            var walkDomain = mapper.Map<Walk>(addWalkRequestDTO);

            walkDomain = await walkRepository.CreateAsync(walkDomain);

            //Convert Domain back to DTO
            var walkDTO = mapper.Map<WalkDTO>(walkDomain);
            return Ok(walkDTO);
        }

        // Update walk
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            // Map DTO to Domain model
            var walkDomain = mapper.Map<Walk>(updateWalkRequestDTO);

            var updatedWalkDomain = await walkRepository.UpdateAsync(id, walkDomain);
            if (updatedWalkDomain == null) { return NotFound(); }

            // Map Domain to DTO
            return Ok(mapper.Map<WalkDTO>(updatedWalkDomain));
        }

        // Delete walk
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.DeleteAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            // map Walk Domain model to DTO
            var walkDto = mapper.Map<WalkDTO>(walkDomain);
            return Ok(walkDto);
        }
    }
}
