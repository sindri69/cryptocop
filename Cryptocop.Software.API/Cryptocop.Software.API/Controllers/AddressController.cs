using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
using System.Linq;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
        _addressService = addressService;
        }

        [HttpGet]
        [Route("", Name = "GetAllAddresses")]
        public IActionResult GetAllAddresses()
        {
            var email = User.Identity.Name;
            return Ok(_addressService.GetAllAddresses(email));
           
        }

        [HttpPost]
        [Route("", Name = "CreateAddress")]
        public IActionResult CreateAddress([FromBody] AddressInputModel addressInput)
        {
             if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var email = User.Identity.Name;
            _addressService.AddAddress(email, addressInput);
    
            return Ok("Address was successfully added");
            
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteAddress")]
        public IActionResult DeleteAddress(int id)
        {
            var email = User.Identity.Name;
            _addressService.DeleteAddress(email, id);
            return NoContent();
        }


        
    }
}