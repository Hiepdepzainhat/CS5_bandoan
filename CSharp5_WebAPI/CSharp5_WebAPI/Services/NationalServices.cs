using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class NationalServices : INationalServices
    {
        private readonly CS5_DbContext _context;
        public NationalServices(CS5_DbContext cS5_DbContext)
        {
            _context = cS5_DbContext;
        }

        public async Task DeleteNational(Guid id)
        {
            var nationnal = _context.Nationals.FirstOrDefault(p => p.NationalID == id);
            _context.Nationals.Remove(nationnal);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<National>> GetAllNational()
        {
            return await _context.Nationals.ToListAsync();
        }

        public async Task<National> GetNationalById(Guid id)
        {
            return _context.Nationals.FirstOrDefault(p => p.NationalID == id);
        }

        public async Task<National> PostNational(National na)
        {
            _context.Nationals.Add(na);
            _context.SaveChanges();
            return na;
        }

        public async Task<National> PutNational(Guid id, National na)
        {
            var nationals = _context.Nationals.FirstOrDefault(p => p.NationalID == id);
            nationals.NationalName = na.NationalName;

            _context.Nationals.Update(nationals);
            _context.SaveChanges();
            return nationals;
        }
    }
}
