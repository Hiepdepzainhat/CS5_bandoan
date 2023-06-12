using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface ICartServices
    {
        public Task<IEnumerable<Cart>> GetAllCart();
        public Task<Cart> PostCart(Cart cart);
        public Task<Cart> PutCart(Guid id,Cart cart);
        public Task DeleteCart(string id);
        public Task<Cart> GetCartById(string id);
    }
}

