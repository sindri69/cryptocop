using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/exchanges")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        // TODO: Setup routes
        [HttpGet]
        [Route("")]
        public IActionResult GetAllExchanges() {
            return Ok();
        }
    }
}