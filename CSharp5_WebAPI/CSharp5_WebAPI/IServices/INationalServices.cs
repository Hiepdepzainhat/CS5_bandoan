using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface INationalServices
    {
        public Task<IEnumerable<National>> GetAllNational(); // getall
        public Task<National> PostNational(National na); // post == create
        public Task<National> PutNational(Guid id, National na); // put == update
        public Task DeleteNational(Guid id);
        public Task<National> GetNationalById(Guid id);// get by ID
    }
}
