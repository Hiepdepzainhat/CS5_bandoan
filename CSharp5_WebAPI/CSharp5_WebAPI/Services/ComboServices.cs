using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace CSharp5_WebAPI.Services
{
    public class ComboServices : IComboServices
    {
        private readonly CS5_DbContext _context;
        public ComboServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteCombo(Guid id)
        {
            var combo = _context.Combos.FirstOrDefault(p => p.ComboID == id);
            _context.Combos.Remove(combo);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Combo>> GetAllCombo()
        {
            return await _context.Combos.ToListAsync();
        }

        public async Task<Combo> GetComboById(Guid id)
        {
            return _context.Combos.FirstOrDefault(p => p.ComboID == id);
        }

        public async Task<Combo> PostCombo(Combo cb)
        {
            await _context.Combos.AddAsync(cb);
            await _context.SaveChangesAsync();
            return cb;
        }

        public async Task<Combo> PutCombo(Guid id, Combo cb)
        {
            var combo = _context.Combos.FirstOrDefault(p => p.ComboID == id);
            combo.ComboName = cb.ComboName;
            combo.ImgCombo = cb.ImgCombo;
            combo.Price = cb.Price;
            combo.Status = cb.Status;

            _context.Combos.Update(combo);
            await _context.SaveChangesAsync();
            return combo;
        }
    }
}
