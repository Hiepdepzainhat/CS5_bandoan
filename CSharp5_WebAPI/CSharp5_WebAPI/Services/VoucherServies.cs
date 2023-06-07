using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;

namespace CSharp5_WebAPI.Services
{
    public class VoucherServies : IVoucherServies
    {
        private readonly CS5_DbContext _context;
        public VoucherServies(CS5_DbContext cS5_DbContext)
        {
            _context = cS5_DbContext;
        }
        public async Task DeleteVoucher(Guid id)
        {
            var voucher = _context.Vouchers.FirstOrDefault(p => p.VoucherID == id);
            _context.Vouchers.Remove(voucher);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Voucher>> GetAllVoucher()
        {
            return _context.Vouchers.ToList();
        }

        public async Task<Voucher> GetVoucherById(Guid id)
        {
            return _context.Vouchers.FirstOrDefault(p => p.VoucherID == id);
        }

        public async Task<Voucher> PostVoucher(Voucher p)
        {
            _context.Vouchers.Add(p);
            _context.SaveChanges();
            return p;
        }

        public async Task<Voucher> PutVoucher(Guid id, Voucher p)
        {
            var voucher = _context.Vouchers.FirstOrDefault(p => p.VoucherID == id);
            voucher.VoucherName = p.VoucherName;
            voucher.PercentageDiscount = p.PercentageDiscount;

            _context.Vouchers.Update(voucher);
            _context.SaveChanges();
            return voucher;
        }
    }
}
