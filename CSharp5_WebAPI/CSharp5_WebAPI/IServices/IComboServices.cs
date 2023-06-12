using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IComboServices
    {
        public Task<IEnumerable<Combo>> GetAllCombo(); 
        public Task<Combo> PostCombo(Combo cb); 
        public Task<Combo> PutCombo(Guid id, Combo cb); 
        public Task DeleteCombo(Guid id);
        public Task<Combo> GetComboById(Guid id);
    }
}
