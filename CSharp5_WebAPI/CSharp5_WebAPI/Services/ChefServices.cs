using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class ChefServices : IChefServices
    {
        private readonly CS5_DbContext _context;
        public ChefServices(CS5_DbContext cS5_DbContext)
        {
            _context = cS5_DbContext;
        }
        public async Task DeleteChef(Guid id)
        {
            var chef = _context.Chefs.FirstOrDefault(p => p.ChefID == id);
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Chef>> GetAllChef()
        {
            return await _context.Chefs.ToListAsync();
        }

        public async Task<Chef> GetChefById(Guid id)
        {
            return _context.Chefs.FirstOrDefault(p => p.ChefID == id);
        }

        public async Task<Chef> PostChef(Chef ch)
        {
            _context.Chefs.Add(ch);
            _context.SaveChanges();
            return ch;
        }

        public async Task<Chef> PutChef(Guid id, Chef ch)
        {
            var chefs = _context.Chefs.FirstOrDefault(p => p.ChefID == id);
            chefs.ChefName = ch.ChefName;
            chefs.ChefDescription = ch.ChefDescription;

            _context.Chefs.Update(chefs);
            _context.SaveChanges();
            return chefs;
        }
    }
}
