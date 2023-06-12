using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using IdGen;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class ProductServices : IProductServices
    {
        private readonly CS5_DbContext _context;
        public ProductServices(CS5_DbContext cS5_DbContext)
        {
            _context = cS5_DbContext;
        }

        public async Task DeleteProducts(Guid id)
        {
            var products = _context.Productss.FirstOrDefault(p => p.ProductID == id);
            _context.Productss.Remove(products);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            return await _context.Productss.ToListAsync();
        }

        public async Task<Products> GetProductsById(Guid id)
        {
            return _context.Productss.FirstOrDefault(p => p.ProductID == id);
        }

/*        public async Task<IEnumerable<Products>> GetProductToCategorie(Guid idCategorie)
        {
            return  _context.Productss.Where(p => p.CategoryID == idCategorie).ToList();
        }
*/
        public async Task<Products> PostProducts(Products p)
        {
            await _context.Productss.AddAsync(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<Products> PutProducts(Guid id, Products p) // p is new products
        {
            var products = _context.Productss.FirstOrDefault(p => p.ProductID == id); // it's old products
            // paste prop new --> old
            products.CategoryID = p.CategoryID;
            products.ChefID = p.ChefID;
            products.IdVoucher = p.IdVoucher;
            products.ProducerID = p.ProducerID;
            products.ProductName = p.ProductName;
            products.Quantity = p.Quantity;
            products.EntryPrice = p.EntryPrice; // giá nhập
            products.DateOfManufacture = p.DateOfManufacture; // NSX
            products.Expired = p.Expired; // HSD
            products.ImPortDate = p.ImPortDate; // Ngay nhap
            products.Price = p.Price;
            products.Status = p.Status;
            products.Desciption = p.Desciption;
         

            _context.Productss.Update(products);
            _context.SaveChanges();
            return products;
        }
    }
}
