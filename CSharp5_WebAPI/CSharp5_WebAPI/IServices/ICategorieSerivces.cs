using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface ICategorieSerivces
    {
        public Task<IEnumerable<Categories>> GetAllCategory();
        public Task<Categories> PostCategory(Categories ca);
        public Task<Categories> PutCategory(Guid id, Categories ca);
        public Task DeleteCategory(Guid id);
        public Task<Categories> GetCategoryById(Guid id);
    }
}
