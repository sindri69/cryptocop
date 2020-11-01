using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

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
            return Ok(_addressService.GetAllAddresses());
        }

        [HttpPost]
        [Route("", Name = "CreateAddress")]
        public IActionResult CreateAddress([FromBody] AddressInputModel Address)
        {
            //error handling
            //ca;; address service
            //what do i return
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