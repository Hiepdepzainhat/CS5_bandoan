using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IUserServices
    {
        public Task<IEnumerable<User>> GetAllUser();
        public Task<User> PostUser(User user);
        public Task<User> PutUser(User u);
        public Task DeleteUser(string id);
        public Task<User> GetUserById(string id);
        public Task<User> Login(string username, string password);
    }
}

