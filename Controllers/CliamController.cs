using System.Collections.Generic;
using System.Threading.Tasks;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager_User_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet("get-all-claims")]
        [Authorize(Policy = "get")]
        public async Task<IActionResult> GetAllClaims()
        {
            var claims = await _claimService.GetAllClaimsAsync();
            return Ok(claims);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "get")]
        public async Task<IActionResult> GetClaimById(int id)
        {
            var claims = await _claimService.GetAllClaimsAsync();
            var claim = claims.Find(c => c.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }
            return Ok(claim);
        }

        [HttpPost("add-claim")]
        [Authorize(Policy = "add")]

        public async Task<IActionResult> AddClaim([FromBody] ClaimDTO claim)
        {
            var createdClaim = await _claimService.AddClaimAsync(claim);
            if (createdClaim == null)
            {
                return BadRequest("Unable to add claim");
            }
            return CreatedAtAction(nameof(GetClaimById), new { id = createdClaim.ClaimId }, createdClaim);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "update")]
        public async Task<IActionResult> UpdateClaim(int id, [FromBody] ClaimDTO claim)
        {
            if (id != claim.ClaimId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedClaim = await _claimService.UpdateClaimAsync(claim);
            if (updatedClaim == null)
            {
                return NotFound();
            }
            return Ok(updatedClaim);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "delete")]
        public async Task<IActionResult> DeleteClaim(int id)
        {
            bool result = await _claimService.DeleteClaimAsync(id);
            if (!result)
            {
                return NotFound("Claim not found");
            }
            return NoContent();
        }
    }
}
