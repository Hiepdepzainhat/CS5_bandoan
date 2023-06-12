using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : ControllerBase
    {
        private readonly ICartDetailServices _services;
        public CartDetailController(ICartDetailServices cartDetail)
        {
            _services = cartDetail;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<CartDetail>> GetAllCartDetail()
        {
            var posts = await _services.GetAllCartDetail();
            return Ok(posts);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<CartDetail>> GetCartDetailById(string id)
        {
            try
            {
                var post = await _services.GetCartDetailById(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<User>> PostCartDetail(int Quantity, int Price, int Total)
        {
            CartDetail cartDetail = new CartDetail();
            cartDetail.Quantity = Quantity; 
            cartDetail.Price = Price;
            cartDetail.ToTal = Total;
            try
            {
                var p = await _services.PostCartDetail(cartDetail);
                return Ok(p);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task DeleteCartDetail(string id)
        {
            await _services.DeleteCartDetail(id);
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<CartDetail>> PutCartDetail(string id, int Quantity, int Price, int Total)
        {
            var p = await _services.PutCartDetail(id, Quantity, Price, Total);
            return Ok(p);
        }
    }
}
