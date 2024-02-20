using ContactFormAPI.IContactForm;
using ContactFormAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactFormAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IContcatFormContracts _contactFormService;

        public ContactFormController(IContcatFormContracts contactFormService)
        {
            _contactFormService = contactFormService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactForm>>> GetContactForms()
        {
            return Ok(await _contactFormService.GetContactForms());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactForm>> GetContactForm(int id)
        {
            var contactForm = await _contactFormService.GetContactForm(id);

            if (contactForm == null)
            {
                return NotFound();
            }

            return contactForm;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactForm(int id, ContactForm contactForm)
        {
            var updatedContactForm = await _contactFormService.UpdateContactForm(id, contactForm);

            if (updatedContactForm == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ContactForm>> AddContactForm(ContactForm contactForm)
        {
            var newContactForm = await _contactFormService.AddContactForm(contactForm);

            return CreatedAtAction("GetContactForm", new { id = newContactForm.Id }, newContactForm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactForm>> DeleteContactForm(int id)
        {
            var contactForm = await _contactFormService.DeleteContactForm(id);

            if (contactForm == null)
            {
                return NotFound();
            }

            return contactForm;
        }
    }
}
