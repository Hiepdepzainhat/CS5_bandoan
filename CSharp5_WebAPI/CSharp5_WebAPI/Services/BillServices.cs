using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class BillServices : IBillServices
    {
        private CS5_DbContext _context;
        public BillServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteBill(string id)
        {
            var bill = _context.Bills.FirstOrDefault(x => x.BillID == Guid.Parse(id));
            _context.Bills.Remove(bill);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Bill>> GetAllBill()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillById(string id)
        {
            return _context.Bills.FirstOrDefault(x => x.BillID == Guid.Parse(id));
        }

        public async Task<Bill> PostBill(Bill bill)
        {
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> PutBill(string id, Bill bill)
        {
            var billnew = _context.Bills.FirstOrDefault(x => x.BillID == Guid.Parse(id));
            billnew.UserID = bill.UserID;
            billnew.CreateDate = bill.CreateDate;
            billnew.Status = bill.Status;
            billnew.Price = bill.Price;
            _context.Bills.Update(billnew);
            await _context.SaveChangesAsync();
            return billnew;
        }
    }
}
