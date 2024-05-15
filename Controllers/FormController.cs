using Microsoft.AspNetCore.Mvc;
using Manager_User_API.DTO;
using Manager_User_API.IServices;
using System.Collections.Generic;

namespace Manager_User_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        [Route("/api/[controller]/get-all-forms")]
        public IActionResult GetAllForms()
        {
            var forms = _formService.GetAllForms();
            return Ok(forms);
        }

        [HttpPost]
        [Route("/api/[controller]/add-form")]

        public IActionResult AddForm([FromBody] FormDTO form)
        {
            var createdForm = _formService.AddForm(form);
            if (createdForm == null)
            {
                return BadRequest("Unable to add form");
            }
            return CreatedAtAction(nameof(GetFormById), new { id = createdForm.FormId }, createdForm);
        }

        [HttpGet("{id}")]

        public IActionResult GetFormById(int id)
        {
            var form = _formService.GetAllForms().Find(f => f.FormId == id);
            if (form == null)
            {
                return NotFound();
            }
            return Ok(form);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateForm(int id, [FromBody] FormDTO form)
        {
            if (id != form.FormId)
            {
                return BadRequest("ID mismatch");
            }
            var updatedForm = _formService.UpdateForm(form);
            if (updatedForm == null)
            {
                return NotFound();
            }
            return Ok(updatedForm);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteForm(int id)
        {
            bool result = _formService.DeleteForm(id);
            if (!result)
            {
                return NotFound("Form not found");
            }
            return NoContent();
        }
    }
}
