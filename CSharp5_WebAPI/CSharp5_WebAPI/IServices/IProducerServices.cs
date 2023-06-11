using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IProducerServices
    {
        public Task<IEnumerable<Producer>> GetAllProducer();
        public Task<Producer> PostProducer(Producer producer);
        public Task<Producer> PutProducer(string id, Producer producer);
        public Task DeleteProducer(string id);
        public Task<Producer> GetProducerById(string id);
    }
}
