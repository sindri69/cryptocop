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
            //get email from claim?
            //return Ok(_addressService.GetAllAddresses(email));
            return Ok();
        }

        [HttpPost]
        [Route("", Name = "CreateAddress")]
        public IActionResult CreateAddress([FromBody] AddressInputModel addressInput)
        {
            var email = User.Identity.Name;
            _addressService.AddAddress(email, addressInput);
            return Ok();
            
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteAddress")]
        public IActionResult DeleteAddress(int id)
        {
            //error handling
            //call address service and do stuff
            return NoContent();
        }


        
    }
}