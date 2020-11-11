using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Implementations;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
        _paymentService = paymentService;
        }

        [HttpGet]
        [Route("", Name = "GetAllPaymentCards")]
        public IActionResult GetAllPaymentCards()
        {
            var email = User.Identity.Name;
            return Ok(_paymentService.GetStoredPaymentCards(email));
        }

        [HttpPost]
        [Route("", Name = "CreatePaymentCard")]
        public IActionResult CreatePaymentCard([FromBody] PaymentCardInputModel paymentCard)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var email = User.Identity.Name;
            _paymentService.AddPaymentCard(email, paymentCard);
            return new ObjectResult("Creditcard added to database") { StatusCode = StatusCodes.Status201Created };
        }
    }
}