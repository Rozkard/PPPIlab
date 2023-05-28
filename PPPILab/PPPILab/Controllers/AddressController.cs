using Microsoft.AspNetCore.Mvc;
using PPPILab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPPILab.Services
{

    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET api/addresses
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAllAddresses()
        {
            var addresses = await _addressService.GetAllAddressesAsync();
            return Ok(addresses);
        }

        // POST api/addresses
        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address address)
        {
            var createdAddress = await _addressService.CreateAddressAsync(address);
            //return CreatedAtAction(nameof(GetAddressById), new { id = createdAddress.Id }, createdAddress);
            return Ok(createdAddress);
        }

        // PUT api/addresses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, Address address)
        {
            await _addressService.UpdateAddressAsync(id, address);
            return NoContent();
        }

        // DELETE api/addresses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return NoContent();
        }
    }
}
