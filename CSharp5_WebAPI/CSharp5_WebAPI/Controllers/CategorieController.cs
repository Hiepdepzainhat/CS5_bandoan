using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieSerivces _categorieSerivces;
        public CategorieController(ICategorieSerivces categorieSerivces)
        {
            _categorieSerivces = categorieSerivces;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Categories>> GetAllCategory()
        {
            var listCategory = await _categorieSerivces.GetAllCategory();
            return Ok(listCategory);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Categories>> GetCategory(Guid id)
        {
            //var listCategory = await _categorieSerivces.GetCategoryById(id);
            //return Ok(listCategory);
            try
            {
                var category = await _categorieSerivces.GetCategoryById(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<Categories>> PostCategory(Categories ca)
        {
            await _categorieSerivces.PostCategory(ca);
            return Ok(ca);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Categories>> UpdateCategory(Guid id, Categories ca)
        {
            await _categorieSerivces.PutCategory(id, ca);
            return Ok(ca);
        }

        [HttpDelete("[action]/{id}")]
        public async Task DeleteCategory(Guid id)
        {
            await _categorieSerivces.DeleteCategory(id);
        }
    }
}
