using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IComboItemServices
    {
        public Task<IEnumerable<ComboItems>> GetAllComboItem();
        public Task<ComboItems> PostComboItem(ComboItems cbi);
        public Task<ComboItems> PutComboItem(Guid id, ComboItems cbi);
        public Task DeleteComboItem(Guid id);
        public Task<ComboItems> GetComboItemById(Guid id);
    }
}
