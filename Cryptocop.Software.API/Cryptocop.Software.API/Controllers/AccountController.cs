using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using System;
using Cryptocop.Software.API.Services.Implementations;
using Cryptocop.Software.API.Services.Interfaces;
using System.Linq;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize] 
    [Route("api/account/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
        _accountService = accountService;
        _tokenService = tokenService;
        }

        //register
        [AllowAnonymous]
        [HttpPost]
        [Route("register", Name = "Register")]

        public IActionResult Register([FromBody] RegisterInputModel user)
        {
                        var claims = User.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
            Console.WriteLine(claims);
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var returnedUser = _accountService.CreateUser(user);
            return Ok(_tokenService.GenerateJwtToken(returnedUser));
        }

        //signin
        [AllowAnonymous]
        [HttpPost]
        [Route("signin", Name = "SignIn")]
        public IActionResult SignIn([FromBody] LoginInputModel login)
        {
            var user = _accountService.AuthenticateUser(login);
             if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            if (user == null) { return Unauthorized(); }
            return Ok(_tokenService.GenerateJwtToken(user));
        }
        //signout
        [HttpGet]
        [Route("signout", Name = "SignOut")]
        public IActionResult SignOut()
        {
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "tokenId").Value, out var tokenId);
            _accountService.Logout(tokenId);
            return NoContent();
        }


    }
}