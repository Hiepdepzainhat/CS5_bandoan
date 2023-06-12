using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/ComboItem")]
    [ApiController]
    public class ComboItemController : ControllerBase
    {
        private readonly IComboItemServices _comboItemServices;
        public ComboItemController(IComboItemServices comboItemServices)
        {
            _comboItemServices = comboItemServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<ComboItems>> GetAllComboItem()
        {
            var comboItems = await _comboItemServices.GetAllComboItem();
            return Ok(comboItems);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ComboItems>> GetComboItem(Guid id)
        {
            try
            {
                var combo = await _comboItemServices.GetComboItemById(id);
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
        public async Task<ActionResult<ComboItems>> PostComboItem(ComboItems cbi)
        {
            try
            {
                var comboItem = await _comboItemServices.PostComboItem(cbi);
                return Ok(comboItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete("[action]/{id}")]
        public async Task DeleteComboItem(Guid id)
        {
            await _comboItemServices.DeleteComboItem(id);
        }


        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<ComboItems>> PutComboItem(Guid id, ComboItems cbi)
        {
            try
            {
                var comboItem = _comboItemServices.GetComboItemById(id);
                if (comboItem == null)
                {
                    return NotFound();
                }
                else
                {
                    await _comboItemServices.PutComboItem(id, cbi);
                    return Ok(comboItem);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
