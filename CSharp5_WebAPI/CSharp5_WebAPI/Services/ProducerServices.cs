using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class ProducerServices : IProducerServices
    {
        private CS5_DbContext _context;
        public ProducerServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteProducer(string id)
        {
            var producer = _context.Producers.FirstOrDefault(x => x.ProducerID == Guid.Parse(id));
            _context.Producers.Remove(producer);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Producer>> GetAllProducer()
        {
            return await _context.Producers.ToListAsync();
        }

        public async Task<Producer> GetProducerById(string id)
        {
            return _context.Producers.FirstOrDefault(x => x.ProducerID == Guid.Parse(id));
        }

        public async Task<Producer> PostProducer(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
            return producer;
        }

        public async Task<Producer> PutProducer(string id, Producer producer)
        {
            var producernew = _context.Producers.FirstOrDefault(x => x.ProducerID == Guid.Parse(id));
            producernew.ProducerName = producer.ProducerName;
            producernew.Description = producer.Description;
            _context.Producers.Update(producernew);
            await _context.SaveChangesAsync();
            return producernew;
        }
    }
}
