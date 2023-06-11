using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/producer")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        public readonly IProducerServices _producerServices;
        public ProducerController(IProducerServices producerServices)
        {
            _producerServices = producerServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Producer>> GetProducers()
        {
            var producers = await _producerServices.GetAllProducer();
            return Ok(producers);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Producer>> GetProducerById(string id)
        {
            try
            {
                var producer = await _producerServices.GetProducerById(id);
                if (producer == null)
                {
                    return NotFound();
                }
                return Ok(producer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Producer>> PostProducer(Producer producer)
        {
            try
            {
                await _producerServices.PostProducer(producer);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Producer>> PutProducer(string id, Producer producer)
        {
            try
            {
                var p = await _producerServices.GetProducerById(id);
                if (p == null)
                {
                    return NotFound();
                }
                else
                {
                    await _producerServices.PutProducer(id, producer);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Producer>> DeleteProducer(string id)
        {
            await _producerServices.DeleteProducer(id);
            return Ok();
        }
    }
}
