using CSharp5_Share.Models;
using CSharp5_WebAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp5_WebAPI.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServices _PostServices;
        public PostController(IPostServices postServices)
        {
            _PostServices = postServices;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Post>> GetAllPost()
        {
            var posts = await _PostServices.GetAllPost();
            return Ok(posts);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Post>> GetPost(string id)
        {
            try
            {
                var post = await _PostServices.GetPostById(id);
                if(post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            try
            {
                var p = await _PostServices.PostPost(post);
                return Ok(p);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task DeletePost(string id)
        {
            await _PostServices.DeletePost(id);
        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<Post>> PutPost(string id, Post post)
        {
            try
            {
                var p = _PostServices.GetPostById(id);
                if(p == null)
                {
                    return NotFound();
                }
                else
                {
                    await _PostServices.PutPost(id,post);
                    return Ok(p);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
