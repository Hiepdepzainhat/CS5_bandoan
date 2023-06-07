using CSharp5_WebAPI.IServices;
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

    }
}
