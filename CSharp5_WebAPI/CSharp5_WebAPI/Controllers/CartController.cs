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
            var post = await _cartServices.GetAllCart();
            return Ok(post);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Cart>> GetCartById(string id)
        {
            try
            {
                var postid = await _cartServices.GetCartById(id);
                if(postid == null)
                {
                    return NotFound();
                }
                return Ok(postid);
            }catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Cart>> PostCart(
            Guid id, string des, int st)
        {
            Cart cart = new Cart();
            cart.UserID = id;
            cart.Desciption = des;
            cart.Status = st;
            try
            {
                var post = await _cartServices.PostCart(cart);
                return Ok(post);
            }catch (Exception)
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
        public async Task<ActionResult<Cart>> PutCart(string id, string description, int status)
        {
            var p = await _cartServices.PutCart(id, description, status);
            return Ok(p);
        }
    }
}
