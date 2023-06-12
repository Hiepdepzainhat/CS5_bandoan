using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IBillDetailServices
    {
        public Task<IEnumerable<BillDetail>> GetAllBillDetail();
        public Task<BillDetail> PostBillDetail(BillDetail billDetail);
        public Task<BillDetail> PutBillDetail(string id, BillDetail billDetail);
        public Task DeleteBillDetail(string id);
        public Task<BillDetail> GetBillDetailById(string id);
    }
}
