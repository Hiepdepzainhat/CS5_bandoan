using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Products>> GetAllProducts()
        {
            var listproduct = await _productServices.GetAllProducts();
            return Ok(listproduct);
        }


        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Products>> GetProductsById(Guid id)
        {
            var listproduct = await _productServices.GetProductsById(id);
            return Ok(listproduct);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Products>> PostProducts(Products p)
        {
            await _productServices.PostProducts(p);
            return Ok(p);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Products>> UpdateProducts(Guid id, Products p)
        {
            await _productServices.PutProducts(id, p);
            return Ok(p);
        }

        [HttpDelete("[action]/{id}")]
        public async Task DeleteProducts(Guid id)
        {
            await _productServices.DeleteProducts(id);
        }
    }
}
