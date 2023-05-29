using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPPILab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPPILab.Services
{

    [Route("api/contacts")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

     
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContactsAsync();
            return Ok(contacts);
        }

       
        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            var createdContact = await _contactService.CreateContactAsync(contact);
  
            return CreatedAtAction(nameof(GetContactById), new { id = createdContact.Id }, createdContact);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            var existingContact = await _contactService.GetContactByIdAsync(id);
            if (existingContact == null)
            {
                return NotFound();
            }
            await _contactService.UpdateContactAsync(id, contact);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var existingContact = await _contactService.GetContactByIdAsync(id);
            if (existingContact == null)
            {
                return NotFound();
            }
            await _contactService.DeleteContactAsync(id);
            return NoContent();
        }
    }
}
