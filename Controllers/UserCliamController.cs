using Manager_User_API.DTO;
using Manager_User_API.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Manager_User_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserClaimController : ControllerBase
    {
        private readonly IUserClaimService _userClaimService;

        public UserClaimController(IUserClaimService userClaimService)
        {
            _userClaimService = userClaimService;
        }

        [HttpGet]
        [Route("/api/[controller]/get-all-user-claims")]
        [Authorize(Policy = "get")]
        public IActionResult GetAllUserClaims()
        {
            var userClaims = _userClaimService.GetAllUserClaims();
            return Ok(userClaims);
        }
        
        [HttpGet("{userId}/{claimId}")]
        [Authorize(Policy = "get")]
        public IActionResult GetUserClaimById(int userId, int claimId)
        {
            var userClaim = _userClaimService.GetUserClaimById(userId, claimId);
            if (userClaim == null)
            {
                return NotFound();
            }
            return Ok(userClaim);
        }

        [HttpPost]
        [Route("/api/[controller]/add-user-claim")]
        [Authorize(Policy = "add")]

        public IActionResult AddUserClaim([FromBody] UserClaimDTO userClaim)
        {
            var createdUserClaim = _userClaimService.AddUserClaim(userClaim);
            if (createdUserClaim == null)
            {
                return BadRequest("Unable to add user claim");
            }
            return CreatedAtAction(nameof(GetUserClaimById), new { userId = createdUserClaim.UserId, claimId = createdUserClaim.ClaimId }, createdUserClaim);
        }

        [HttpPut("{userId}/{claimId}")]
        [Authorize(Policy = "update")]
        public IActionResult UpdateUserClaim(int userId, int claimId, [FromBody] UserClaimDTO userClaim)
        {
            if (userId != userClaim.UserId || claimId != userClaim.ClaimId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedUserClaim = _userClaimService.UpdateUserClaim(userClaim);
            if (updatedUserClaim == null)
            {
                return NotFound();
            }
            return Ok(updatedUserClaim);
        }

        [HttpDelete("{userId}/{claimId}")]
        [Authorize(Policy = "delete")]
        public IActionResult DeleteUserClaim(int userId, int claimId)
        {
            bool result = _userClaimService.DeleteUserClaim(userId, claimId);
            if (!result)
            {
                return NotFound("User claim not found");
            }
            return NoContent();
        }
    }
}
