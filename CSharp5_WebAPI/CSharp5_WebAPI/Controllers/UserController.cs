using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userSevices;
        private readonly ICartServices _cartServices;
        public UserController(IUserServices userServices, ICartServices cartServices)
        {
            _userSevices = userServices;
            _cartServices = cartServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<User>> GetAllUser()
        {
            var posts = await _userSevices.GetAllUser();
            return Ok(posts);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Role>> GetUser(string id)
        {
            try
            {
                var post = await _userSevices.GetUserById(id);
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
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                await _userSevices.PostUser(user);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task DeleteUser(string id)
        {
            await _userSevices.DeleteUser(id);
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<User>> PutUser(User u)
        {
            var p = await _userSevices.PutUser(u);
            return Ok(p);
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<User>> Login(string username, string password)
        {
            var u = await _userSevices.Login(username, password);
            return Ok(u);
        }
    }
}
