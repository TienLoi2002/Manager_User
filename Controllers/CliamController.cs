using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimController : Controller
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        [Route("/api/[controller]/get-all-claims")]
        public IActionResult GetAllClaims()
        {
            var claims = _claimService.GetAllClaims();
            return Ok(claims);
        }

        [HttpPost]
        [Route("/api/[controller]/add-claim")]

        public IActionResult AddClaim([FromBody] ClaimDTO claim)
        {
            var createdClaim = _claimService.AddClaim(claim);
            if (createdClaim == null)
            {
                return BadRequest("Unable to add claim");
            }
            return CreatedAtAction(nameof(GetClaimById), new { id = createdClaim.ClaimId }, createdClaim);
        }

        [HttpGet("{id}")]

        public IActionResult GetClaimById(int id)
        {
            var claim = _claimService.GetAllClaims().Find(c => c.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }
            return Ok(claim);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateClaim(int id, [FromBody] ClaimDTO claim)
        {
            if (id != claim.ClaimId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedClaim = _claimService.UpdateClaim(claim);
            if (updatedClaim == null)
            {
                return NotFound();
            }
            return Ok(updatedClaim);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteClaim(int id)
        {
            bool result = _claimService.DeleteClaim(id);
            if (!result)
            {
                return NotFound("Claim not found");
            }
            return NoContent();
        }
    }
}
