using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
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
        public async Task<ActionResult<User>> PostUser(string name, Guid roleID,Guid nationalID,string username, string password, string phonenumber, string address, DateTime dateofbirthday, int sex, string imguser)
        {
            User user = new User();
            user.UserID = Guid.NewGuid();
            user.RoleID = roleID;
            user.NationalID = nationalID;
            user.Name = name;
            user.UserName = username;
            user.PassWord = password;
            user.PhoneNumber = phonenumber;
            user.Address = address;
            user.DateOfBirth = dateofbirthday;
            user.Sex = sex;
            user.ImgUser = imguser;

            try
            {               
                var p = await _userSevices.PostUser(user);
                Cart cart = new Cart();
                cart.UserID = user.UserID;
                cart.Desciption = "";
                cart.Status = 1;
                var c = await _cartServices.PostCart(cart);
                return Ok(p);
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
        public async Task<ActionResult<User>> PutUser(string id, string name,Guid nationalID, string username, string password, string phonenumber, string address, DateTime dateofbirthday, int sex, string imguser)
        {
            var p = await _userSevices.PutUser(id, name, username, nationalID, password, phonenumber,address,dateofbirthday,sex, imguser);
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
