using Manager_User_API.DTO;
using Manager_User_API.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager_User_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet("get-all-positions")]
        public async Task<IActionResult> GetAllPositionsAsync()
        {
            var positions = await _positionService.GetAllPositionsAsync();
            return Ok(positions);
        }

        [HttpPost("add-position")]
        public async Task<IActionResult> AddPositionAsync([FromBody] PositionDTO position)
        {
            var createdPosition = await _positionService.AddPositionAsync(position);
            if (createdPosition == null)
            {
                return BadRequest("Unable to add position");
            }
            return CreatedAtAction(nameof(GetPositionByIdAsync), new { id = createdPosition.PositionId }, createdPosition);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPositionByIdAsync(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePositionAsync(int id, [FromBody] PositionDTO position)
        {
            if (id != position.PositionId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedPosition = await _positionService.UpdatePositionAsync(position);
            if (updatedPosition == null)
            {
                return NotFound();
            }
            return Ok(updatedPosition);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositionAsync(int id)
        {
            bool result = await _positionService.DeletePositionAsync(id);
            if (!result)
            {
                return NotFound("Position not found");
            }
            return NoContent();
        }
    }
}
