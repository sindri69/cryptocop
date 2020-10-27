using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        [Route("", Name = "GetAllPaymentCards")]
        public IActionResult GetAllPaymentCards()
        {
            //error handling
            //call paymentService
            //return something
            return Ok();
        }

        [HttpPost]
        [Route("", Name = "CreatePaymentCard")]
        public IActionResult CreatePaymentCard([FromBody] PaymentCardInputModel paymentCard)
        {
            //error handling
            //call paymentcard service
            //return something
            return Ok();
        }
    }
}