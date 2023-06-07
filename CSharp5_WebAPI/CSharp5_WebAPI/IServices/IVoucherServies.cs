using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IVoucherServies
    {
        public Task<IEnumerable<Voucher>> GetAllVoucher(); // getall
        public Task<Voucher> PostVoucher(Voucher p); // post == create
        public Task<Voucher> PutVoucher(Guid id, Voucher p); // put == update
        public Task DeleteVoucher(Guid id);
        public Task<Voucher> GetVoucherById(Guid id);// get by ID
    }
}
