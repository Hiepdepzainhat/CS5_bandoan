using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleSevices;
        public RoleController(IRoleServices roleSevices)
        {
            _roleSevices = roleSevices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Role>> GetAllRole()
        {
            var posts = await _roleSevices.GetAllRole();
            return Ok(posts);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Role>> GetRole(string id)
        {
            try
            {
                var post = await _roleSevices.GetRoleById(id);
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
        public async Task<ActionResult<Role>> PostRole(string roleName)
        {
            Role role = new Role();
            role.RoleID = Guid.NewGuid();
            role.RoleName = roleName;
            try
            {
                var p = await _roleSevices.PostRole(role);
                return Ok(p);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task DeleteRole(string id)
        {
            await _roleSevices.DeleteRole(id);
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Role>> PutRole(string id, string name)
        {    
            var p =   await _roleSevices.PutRole(id,name);
            return Ok(p);
        }
    }
}
