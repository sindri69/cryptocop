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
        [AllowAnonymous]
        [HttpPost]
        [Route("register", Name = "Register")]

        public IActionResult Register([FromBody] RegisterInputModel user)
        {
            //todo call register service
            return Ok();
        }

        //signin
        [AllowAnonymous]
        [HttpPost]
        [Route("signin", Name = "SignIn")]
        public IActionResult SignIn([FromBody] LoginInputModel login)
        {
            //TODO call a authentication service
            //TODO return valid JWT token
            return Ok();
        }
        //signout
        [HttpGet]
        [Route("signout", Name = "SignOut")]
        public IActionResult SignOut()
        {
            //TODO retrieve token id from claim and blacklist token
            return NoContent();
        }

        //hann er med getuserinfo route

    }
}