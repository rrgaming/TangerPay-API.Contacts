using Contracts.Contact;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContact _ic;

        public ContactController(ILogger<ContactController> logger, IContact ic)
        {
            _logger = logger;
            _ic = ic;
        }

        [HttpGet("recordContactDetails/{id}")]
        public ActionResult GetContactById(int id)
        {
            try
            {
                var contact = _ic.GetContactById(id);
                if (contact == null)
                {
                    return StatusCode(404, new { errorMessage = $"Contact with id = {id} not found." });
                }
                else 
                {
                    return Ok(contact);
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on ContactController/GetContactById");
                return StatusCode(500, new {errorMessage = $"Error occured on recordContactDetails endpoint: {ex.Message}" });
            }
        }

        [HttpPost("recordContactDetails")]
        public async Task<ActionResult> AddContact([FromBody] AddContactModel model)
        {
            try
            {
                int newId = await _ic.AddContactById(model);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on ContactController/GetContactById");
                return StatusCode(500, new { errorMessage = $"Error occured on recordContactDetails endpoint: {ex.Message}" });
            }
        }
    }
}