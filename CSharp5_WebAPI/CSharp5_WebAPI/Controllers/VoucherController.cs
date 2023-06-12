using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/Voucher")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherServies _voucherServies;
        public VoucherController(IVoucherServies voucherServies)
        {
            _voucherServies = voucherServies;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Voucher>> GetAllVoucher()
        {
            var listVoucher = await _voucherServies.GetAllVoucher();
            return Ok(listVoucher);
        }


        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Voucher>> GetVoucherById(Guid id)
        {
            var listVoucher = await _voucherServies.GetVoucherById(id);
            return Ok(listVoucher);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Voucher>> PostVoucher(Voucher p)
        {
            await _voucherServies.PostVoucher(p);
            return Ok(p);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Voucher>> UpdateVoucher(Guid id, Voucher p)
        {
            await _voucherServies.PutVoucher(id, p);
            return Ok(p);
        }

        [HttpDelete("[action]/{id}")]
        public async Task DeleteVoucher(Guid id)
        {
            await _voucherServies.DeleteVoucher(id);
        }
    }
}
