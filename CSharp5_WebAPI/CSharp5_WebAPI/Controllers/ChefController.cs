using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly IChefServices _chefServices;
        public ChefController(IChefServices chefServices)
        {
            _chefServices = chefServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Chef>> GetAllChef()
        {
            var listChef = await _chefServices.GetAllChef();
            return Ok(listChef);
        }


        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Chef>> GetChef(Guid id)
        {
            //var listChef = await _chefServices.GetChefById(id);
            //return Ok(listChef);
            try
            {
                var chef = await _chefServices.GetChefById(id);
                if (chef == null)
                {
                    return NotFound();
                }
                return Ok(chef);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<Chef>> PostChef(Chef ch)
        {
            await _chefServices.PostChef(ch);
            return Ok(ch);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Chef>> UpdateChef(Guid id, Chef ch)
        {
            await _chefServices.PutChef(id, ch);
            return Ok(ch);
        }

        [HttpDelete("[action]/{id}")]
        public async Task DeleteChef(Guid id)
        {
            await _chefServices.DeleteChef(id);
        }
    }
}
