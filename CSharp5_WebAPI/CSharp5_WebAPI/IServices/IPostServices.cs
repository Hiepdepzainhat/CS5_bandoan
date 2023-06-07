using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IPostServices
    {
        public Task<IEnumerable<Post>> GetAllPost();
        public Task<Post> PostPost(Post post);
        public Task<Post> PutPost(string id, Post post);
        public Task DeletePost(string id);
        public Task<Post> GetPostById(string id);
    }
}
