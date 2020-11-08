using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
        _shoppingCartService = shoppingCartService;
        }

        
        [HttpPost]
        [Route("", Name = "CreateShoppingCartItem")]
        public IActionResult CreateShoppingCartItem([FromBody] ShoppingCartItemInputModel shoppingCartItem)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var email = User.Identity.Name;
            //return created?
            _shoppingCartService.AddCartItem(email, shoppingCartItem);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteShoppingCartItem")]
        public IActionResult DeleteShoppingCartItem(int id)
        {
            var email = User.Identity.Name;
            _shoppingCartService.RemoveCartItem(email, id);
            return NoContent();
            
        }

        [HttpPatch]
        [Route("{id:int}", Name = "UpdateShoppingCartItem")]
        public IActionResult UpdateShoppingCartItem([FromBody] ShoppingCartItemInputModel shoppingCartItem, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var email = User.Identity.Name;
            //_shoppingCartService.UpdateCartItemQuantity(email, id, shoppingCartItem.Quantity);
            return Ok();
        }

        [HttpDelete]
        [Route("", Name = "ClearShoppingCart")]
        public IActionResult ClearShoppingCart()
        {
            var email = User.Identity.Name;
            _shoppingCartService.ClearCart(email);
            return NoContent();
        }
    }
}