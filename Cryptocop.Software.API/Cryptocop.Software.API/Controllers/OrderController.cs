using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
        _orderService = orderService;
        }

        [HttpGet]
        [Route("", Name = "GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var email = User.Identity.Name;
            //.Result
            return Ok(_orderService.GetOrders(email));
        }

        [HttpPost]
        [Route("", Name = "CreateOrder")]
        public IActionResult CreateOrder([FromBody] OrderInputModel order)
        {
            var email = User.Identity.Name;
            _orderService.CreateNewOrder(email, order);
            return new ObjectResult("Order added to database") { StatusCode = StatusCodes.Status201Created };
        }
    }
}