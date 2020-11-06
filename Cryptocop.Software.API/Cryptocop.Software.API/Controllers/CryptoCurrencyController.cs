﻿using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/cryptocurrencies")]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly ICryptoCurrencyService _cryptoCurrencyService;

        public CryptoCurrencyController(ICryptoCurrencyService cryptoCurrencyService)
        {
        _cryptoCurrencyService = cryptoCurrencyService;
        }

        [HttpGet]
        [Route("", Name = "GetAllCryptoCurrencies")]
        public IActionResult GetAllCryptoCurrencies(){
            return Ok(_cryptoCurrencyService.GetAvailableCryptocurrencies());
        }
    }
}
