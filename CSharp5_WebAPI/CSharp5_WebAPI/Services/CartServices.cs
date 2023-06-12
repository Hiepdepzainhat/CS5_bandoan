using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class CartServices : ICartServices
    {
        private CS5_DbContext _context;
        public CartServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteCart(string id)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.UserID == Guid.Parse(id));
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Cart>> GetAllCart()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> GetCartById(string id)
        {
            return _context.Carts.FirstOrDefault(x => x.UserID == Guid.Parse(id));
        }

        public async Task<Cart> PostCart(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> PutCart(string id, string Description, int status)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.UserID == Guid.Parse(id));
            cart.Desciption = Description;
            cart.Status = status;
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            return cart;

        }
    }
}
