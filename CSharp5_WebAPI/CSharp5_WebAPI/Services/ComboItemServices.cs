using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class ComboItemServices : IComboItemServices
    {
        private readonly CS5_DbContext _context;
        public ComboItemServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteComboItem(Guid id)
        {
            var comboItem = _context.ComboItems.FirstOrDefault(p => p.ComboItemID == id);
            _context.ComboItems.Remove(comboItem);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ComboItems>> GetAllComboItem()
        {
            return await _context.ComboItems.ToListAsync();
        }

        public async Task<ComboItems> GetComboItemById(Guid id)
        {
            return _context.ComboItems.FirstOrDefault(p => p.ComboItemID == id);
        }

        public async Task<ComboItems> PostComboItem(ComboItems cbi)
        {
            await _context.ComboItems.AddAsync(cbi);
            await _context.SaveChangesAsync();
            return cbi;
        }

        
        public async Task<ComboItems> PutComboItem(Guid id, ComboItems cbi)
        {
            var comboItem = await _context.ComboItems.FindAsync(id);

            
                comboItem.Price = cbi.Price;
                

                _context.ComboItems.Update(comboItem);
                await _context.SaveChangesAsync();
            

            return comboItem;
        }
    }
}
