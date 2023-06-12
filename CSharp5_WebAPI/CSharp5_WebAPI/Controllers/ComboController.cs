using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/Combo")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        private readonly IComboServices _comboServices;
        public ComboController(IComboServices comboServices)
        {
            _comboServices = comboServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Combo>> GetAllCombo()
        {
            var combos = await _comboServices.GetAllCombo();
            return Ok(combos);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Combo>> GetCombo(Guid id)
        {
            try
            {
                var combo = await _comboServices.GetComboById(id);
                if (combo == null)
                {
                    return NotFound();
                }
                return Ok(combo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Combo>> PostCombo(Combo cb)
        {
            try
            {
                var combo = await _comboServices.PostCombo(cb);
                return Ok(combo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task DeleteCombo(Guid id)
        {
            await _comboServices.DeleteCombo(id);
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Combo>> PutCombo(Guid id,Combo cb)
        {
            try
            {
                var combo = _comboServices.GetComboById(id);
                if (combo == null)
                {
                    return NotFound();
                }
                else
                {
                    await _comboServices.PutCombo(id,cb);
                    return Ok(combo);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
