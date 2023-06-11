using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/billdetail")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        public readonly IBillDetailServices _billDetailServices;
        public BillDetailController(IBillDetailServices billDetailServices)
        {
            _billDetailServices = billDetailServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<BillDetail>> GetBillDetails()
        {
            var billDetails = await _billDetailServices.GetAllBillDetail();
            return Ok(billDetails);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<BillDetail>> GetBillDetailById(string id)
        {
            try
            {
                var billDetail = await _billDetailServices.GetBillDetailById(id);
                if (billDetail == null)
                {
                    return NotFound();
                }
                return Ok(billDetail);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<BillDetail>> PostBillDetail(BillDetail billDetail)
        {
            try
            {
                await _billDetailServices.PostBillDetail(billDetail);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<BillDetail>> PutBillDetail(string id, BillDetail billDetail)
        {
            try
            {
                var bd= await _billDetailServices.GetBillDetailById(id);
                if (bd == null)
                {
                    return NotFound();
                }
                else
                {
                    await _billDetailServices.PutBillDetail(id, billDetail);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<BillDetail>> DeleteBillDetail(string id)
        {
            await _billDetailServices.DeleteBillDetail(id);
            return Ok();
        }
    }
}
