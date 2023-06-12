using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface ICartDetailServices
    {
        public Task<IEnumerable<CartDetail>> GetAllCartDetail();
        public Task<CartDetail> PostCartDetail(CartDetail cartDetail);
        public Task<CartDetail> PutCartDetail(string id, int Quantity, int Price, int Total);
        public Task DeleteCartDetail(string id);
        public Task<CartDetail> GetCartDetailById(string id);
    }
}

