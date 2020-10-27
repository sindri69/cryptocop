using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/cryptocurrencies")]
    public class CryptoCurrencyController : ControllerBase
    {
        // TODO: Setup routes
        [HttpGet]
        [Route("", Name = "GetAllCryptoCurrencies")]
        public IActionResult GetAllCryptoCurrencies(){
            //todo call service
            //return Cryptocurrencies
            return Ok();
        }
    }
}
