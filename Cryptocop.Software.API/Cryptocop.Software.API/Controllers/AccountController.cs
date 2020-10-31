using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using System;
using Cryptocop.Software.API.Services.Implementations;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize] 
    [Route("api/account/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
      _accountService = accountService;
    }

    //register
    [AllowAnonymous]
        [HttpPost]
        [Route("register", Name = "Register")]

        public IActionResult Register([FromBody] RegisterInputModel user)
        {
            
            Console.WriteLine("hello");
            return Ok(_accountService.CreateUser(user));
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