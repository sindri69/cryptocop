using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        // TODO: Setup routes
        [HttpPost]
        [Route("", Name = "CreateShoppingCartItem")]
        public IActionResult CreateShoppingCartItem([FromBody] ShoppingCartItemInputModel shoppingCartItem)
        {
            //todo call service layer
            // return the shopping cart item?
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteShoppingCartItem")]
        public IActionResult DeleteShoppingCartItem(int id)
        {
            //todo call shoppingcart service
            return Ok();
            //return no content?
        }

        [HttpPatch]
        [Route("{id:int}", Name = "UpdateShoppingCartItem")]
        public IActionResult UpdateShoppingCartItem([FromBody] ShoppingCartItemInputModel shoppingCartItem, int id)
        {
            //todo call shoppingcart service
            return Ok();
            // if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            
            // _newsItemService.UpdateNewsItemById(newsItem, id);

            // return GetNewsItemById(id);
        }

        [HttpDelete]
        [Route("", Name = "DeleteShoppingCart")]
        public IActionResult DeleteShoppingCart()
        {
            //call shopping cart service
            return NoContent();
        }
    }
}