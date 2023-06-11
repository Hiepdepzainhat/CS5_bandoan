using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IBillServices
    {
        public Task<IEnumerable<Bill>> GetAllBill();
        public Task<Bill> PostBill(Bill bill);
        public Task<Bill> PutBill(string id, Bill bill);
        public Task DeleteBill(string id);
        public Task<Bill> GetBillById(string id);
    }
}
