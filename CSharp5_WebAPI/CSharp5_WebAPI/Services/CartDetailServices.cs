using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class CartDetailServices : ICartDetailServices
    {
        private CS5_DbContext _context;
        public CartDetailServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteCartDetail(string id)
            {
                var cart = _context.CartDetails.FirstOrDefault(x => x.CDID == Guid.Parse(id));
                _context.CartDetails.Remove(cart);
                _context.SaveChanges();
            }

            public async Task<IEnumerable<CartDetail>> GetAllCartDetail()
            {
                return await _context.CartDetails.ToListAsync();
            }

            public async Task<CartDetail> GetCartDetailById(string id)
            {
                return _context.CartDetails.FirstOrDefault(x => x.CDID == Guid.Parse(id));
            }

            public async Task<CartDetail> PostCartDetail(CartDetail cart)
            {
                await _context.CartDetails.AddAsync(cart);
                await _context.SaveChangesAsync();
                return cart;
            }

            public async Task<CartDetail> PutCartDetail(string id, int Quantity, int Price, int Total)
            {
                var cart = _context.CartDetails.FirstOrDefault(x => x.CDID == Guid.Parse(id));
                cart.Quantity = Quantity;
                cart.Price = Price;
                cart.ToTal = Total;
                _context.CartDetails.Update(cart);
                await _context.SaveChangesAsync();
                return cart;


            
        }
    }
}
