using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        [Route("", Name = "GetAllAddresses")]
        public IActionResult GetAllAddresses()
        {
            //return Ok(_addressService.GetAllAddresses());
            return Ok();
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