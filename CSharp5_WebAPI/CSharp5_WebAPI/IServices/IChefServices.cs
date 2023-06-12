using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IChefServices
    {
        public Task<IEnumerable<Chef>> GetAllChef();
        public Task<Chef> PostChef(Chef ch);
        public Task<Chef> PutChef(Guid id, Chef ch);
        public Task DeleteChef(Guid id);
        public Task<Chef> GetChefById(Guid id);
    }
}
