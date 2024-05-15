using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        [Route("/api/[controller]/get-all-positions")]
        public IActionResult GetAllPositions()
        {
            var positions = _positionService.GetAllPositions();
            return Ok(positions);
        }

        [HttpPost]
        [Route("/api/[controller]/add-position")]

        public IActionResult AddPosition([FromBody] PositionDTO position)
        {
            var createdPosition = _positionService.AddPosition(position);
            if (createdPosition == null)
            {
                return BadRequest("Unable to add position");
            }
            return CreatedAtAction(nameof(GetPositionById), new { id = createdPosition.PositionId }, createdPosition);
        }

        [HttpGet("{id}")]

        public IActionResult GetPositionById(int id)
        {
            var position = _positionService.GetAllPositions().Find(p => p.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }

        [HttpPut("{id}")]

        public IActionResult UpdatePosition(int id, [FromBody] PositionDTO position)
        {
            if (id != position.PositionId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedPosition = _positionService.UpdatePosition(position);
            if (updatedPosition == null)
            {
                return NotFound();
            }
            return Ok(updatedPosition);
        }

        [HttpDelete("{id}")]

        public IActionResult DeletePosition(int id)
        {
            bool result = _positionService.DeletePosition(id);
            if (!result)
            {
                return NotFound("Position not found");
            }
            return NoContent();
        }
    }
}
