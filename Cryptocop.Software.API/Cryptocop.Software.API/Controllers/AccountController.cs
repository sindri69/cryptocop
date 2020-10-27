using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize] //ekki viss af hverju thetta er herna
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //register
        //signin
        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn([FromBody] LoginInputModel login)
        {
            //TODO call a authentication service
            //TODO return valid JWT token
            return Ok();
        }
        //signout
        [HttpGet]
        [Route("signout")]
        public IActionResult SignOut()
        {
            //TODO retrieve token id from claim and blacklist token
            return NoContent();
        }

        //hann er med getuserinfo route

    }
}