using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        public readonly IBillServices _billServices;
        public BillController(IBillServices billServices)
        {
            _billServices = billServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Bill>> GetBills()
        {
            var bills = await _billServices.GetAllBill();
            return Ok(bills);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Bill>> GetBillById(string id)
        {
            try
            {
                var bill = await _billServices.GetBillById(id);
                if (bill == null)
                {
                    return NotFound();
                }
                return Ok(bill);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Bill>> PostBill(Bill bill)
        {
            try
            {
                await _billServices.PostBill(bill);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Bill>> PutBill(string id, Bill bill)
        {
            try
            {
                var b = await _billServices.GetBillById(id);
                if (b == null)
                {
                    return NotFound();
                }
                else
                {
                    await _billServices.PutBill(id, bill);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Bill>> DeleteBill(string id)
        {
            await _billServices.DeleteBill(id);
            return Ok();
        }
    }
}
