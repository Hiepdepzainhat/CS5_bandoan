using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalsController : ControllerBase
    {
        private readonly INationalServices _nationalServices;
        public NationalsController(INationalServices nationalServices)
        {
            _nationalServices = nationalServices;
        }

        [HttpGet]
        public async Task<ActionResult<National>> GetAllNational()
        {
            var listNational = await _nationalServices.GetAllNational();
            return Ok(listNational);
        }


        [HttpGet("id")]
        public async Task<ActionResult<National>> GetNationalById(Guid id)
        {
            var listNational = await _nationalServices.GetNationalById(id);
            return Ok(listNational);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<National>> PostNational(National na)
        {
            await _nationalServices.PostNational(na);
            return Ok(na);
        }

        [HttpPut("id")]
        public async Task<ActionResult<National>> UpdateNational(Guid id, National na)
        {
            await _nationalServices.PutNational(id, na);
            return Ok(na);
        }

        [HttpDelete("id")]
        public async Task DeleteNational(Guid id)
        {
            await _nationalServices.DeleteNational(id);
        }
    }
}
