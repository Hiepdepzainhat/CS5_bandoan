using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class BillDetailServices : IBillDetailServices
    {
        private CS5_DbContext _context;
        public BillDetailServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteBillDetail(string id)
        {
            var billdetail = _context.BillDetails.FirstOrDefault(x => x.BillDetailID == Guid.Parse(id));
            _context.BillDetails.Remove(billdetail);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<BillDetail>> GetAllBillDetail()
        {
            return await _context.BillDetails.ToListAsync();
        }

        public async Task<BillDetail> GetBillDetailById(string id)
        {
            return _context.BillDetails.FirstOrDefault(x => x.BillDetailID == Guid.Parse(id));
        }

        public async Task<BillDetail> PostBillDetail(BillDetail billDetail)
        {
            await _context.BillDetails.AddAsync(billDetail);
            await _context.SaveChangesAsync();
            return billDetail;
        }

        public async Task<BillDetail> PutBillDetail(string id, BillDetail billDetail)
        {
            var billdetailnew = _context.BillDetails.FirstOrDefault(x => x.BillDetailID == Guid.Parse(id));
            billdetailnew.Quantity = billDetail.Quantity;
            billdetailnew.Price = billDetail.Price;
            _context.BillDetails.Update(billdetailnew);
            await _context.SaveChangesAsync();
            return billdetailnew;
        }
    }
}
