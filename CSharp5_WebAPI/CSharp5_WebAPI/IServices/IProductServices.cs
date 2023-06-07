using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IProductServices
    {
        public Task<IEnumerable<Products>> GetAllProducts(); // getall
        public Task<Products> PostProducts(Products p); // post == create
        public Task<Products> PutProducts(Guid id, Products p); // put == update
        public Task DeleteProducts(Guid id);
        public Task<Products> GetProductsById(Guid id);// get by ID
    }
}
