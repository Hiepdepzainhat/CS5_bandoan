using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Data;

namespace CSharp5_WebAPI.Services
{
    public class PostServices : IPostServices
    {
        private CS5_DbContext _context;
        public PostServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeletePost(string id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.PostID == Guid.Parse(id));
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Post>> GetAllPost()
        {
            return await _context.Posts.ToListAsync();
        }
    

        public async Task<Post> GetPostById(string id)
        {
            return _context.Posts.FirstOrDefault(x => x.PostID == Guid.Parse(id));
        }

        public async Task<Post> PostPost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> PutPost(string id, Post post)
        {
            var p = _context.Posts.FirstOrDefault(x => x.PostID == Guid.Parse(id));
            p.Content = post.Content;
            p.ImgPost = post.ImgPost;
            p.CreateDate = post.CreateDate;
            p.TiTlePost = post.TiTlePost;
            _context.Posts.Update(p);
            await _context.SaveChangesAsync();
            return p;
        }
    }
}
