using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Manager_User_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet("get-all-forms")]
        [Authorize(Policy = "get")]
        public async Task<IActionResult> GetAllFormsAsync()
        {
            var forms = await _formService.GetAllFormsAsync();
            return Ok(forms);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "get")]
        public async Task<IActionResult> GetFormByIdAsync(int id)
        {
            var forms = await _formService.GetAllFormsAsync();
            var form = forms.Find(f => f.FormId == id);
            if (form == null)
            {
                return NotFound();
            }
            return Ok(form);
        }

        [HttpPost("add-form")]
        [Authorize(Policy = "add")]
        public async Task<IActionResult> AddFormAsync([FromForm] FormDTO form, [FromForm] IFormFile image)
        {
            var createdForm = await _formService.AddFormAsync(form, image);
            if (createdForm == null)
            {
                return BadRequest("Unable to add form");
            }
            return Ok("Add success");

        }


        [HttpPut("{id}")]
        [Authorize(Policy = "update")]
        public async Task<IActionResult> UpdateFormAsync(int id, [FromBody] FormDTO form)
        {
            if (id != form.FormId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedForm = await _formService.UpdateFormAsync(form);
            if (updatedForm == null)
            {
                return NotFound();
            }
            return Ok(updatedForm);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "delete")]
        public async Task<IActionResult> DeleteFormAsync(int id)
        {
            bool result = await _formService.DeleteFormAsync(id);
            if (!result)
            {
                return NotFound("Form not found");
            }
            return NoContent();
        }
    }
}
