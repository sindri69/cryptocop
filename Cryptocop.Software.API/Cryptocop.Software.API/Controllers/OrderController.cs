using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route("", Name = "GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            //error handling
            //call order service
            //return a list of all orders
            return Ok();
        }

        [HttpPost]
        [Route("", Name = "CreateOrder")]
        public IActionResult CreateOrder([FromBody] OrderInputModel order)
        {
            //error handling 
            //call service layer
            //return something
            return Ok();
        }
    }
}