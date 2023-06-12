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
        /*public async Task<ActionResult<Products>> GetProductsByCategories(Guid idcate)
        {
            var listproduct = await _productServices.GetProductToCategorie(idcate);
            return Ok(listproduct);
        }*/

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Products>> GetProductsById(Guid id)
        {
            try
            {
                var products = await _productServices.GetProductsById(id);
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Products>> PostProducts(Products p)
        {
            try
            {
                await _productServices.PostProducts(p);
                return Ok(p);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
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
