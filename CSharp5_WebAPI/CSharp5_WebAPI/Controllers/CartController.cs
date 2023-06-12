using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Cart>> GetAllCart()
        {
            var carts = await _cartServices.GetAllCart();
            return Ok(carts);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Cart>> GetCartById(string id)
        {
            try
            {
                var carts = await _cartServices.GetCartById(id);
                if (carts == null)
                {
                    return NotFound();
                }
                return Ok(carts);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Cart>> PostCart(Cart c)
        {
            try
            {
                await _cartServices.PostCart(c);
                return Ok(c);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task DeleteCart(string id)
        {
            await _cartServices.DeleteCart(id);
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Cart>> PutCart(Guid id,Cart cart)
        {
            var p = await _cartServices.PutCart(id, cart);
            return Ok(p);
        }
    }
}
