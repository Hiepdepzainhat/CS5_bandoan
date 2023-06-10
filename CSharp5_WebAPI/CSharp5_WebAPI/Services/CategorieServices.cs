using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class CategorieServices : ICategorieSerivces
    {
        private readonly CS5_DbContext _context;
        public CategorieServices(CS5_DbContext cS5_DbContext)
        {
            _context = cS5_DbContext;
        }
        public async Task DeleteCategory(Guid id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryID == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Categories>> GetAllCategory()
        {
            return await _context.Categories.ToArrayAsync();
        }

        public async Task<Categories> GetCategoryById(Guid id)
        {
            return _context.Categories.FirstOrDefault(p => p.CategoryID == id);
        }

        public async Task<Categories> PostCategory(Categories ca)
        {
            _context.Categories.Add(ca);
            _context.SaveChanges();
            return ca;
        }

        public async Task<Categories> PutCategory(Guid id, Categories ca)
        {
            var categories = _context.Categories.FirstOrDefault(p => p.CategoryID == id);
            categories.CategoryName = ca.CategoryName;
            categories.Status = ca.Status;

            _context.Categories.Update(categories);
            _context.SaveChanges();
            return categories;
        }
    }
}
