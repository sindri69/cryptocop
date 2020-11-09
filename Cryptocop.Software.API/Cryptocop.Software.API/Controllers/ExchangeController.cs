using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/exchanges")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
        _exchangeService = exchangeService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllExchanges([FromQuery(Name = "pageNumber")] int pageNumber) {
            return Ok(_exchangeService.GetExchanges(pageNumber).Result);
        }
    }
}