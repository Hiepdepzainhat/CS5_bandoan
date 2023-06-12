using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IUserServices
    {
        public Task<IEnumerable<User>> GetAllUser();
        public Task<User> PostUser(User user);
        public Task<User> PutUser(string id, string name, string username,Guid nationalID, string password, string phonenumber, string address, DateTime dateofbirthday, int sex, string imguser);
        public Task DeleteUser(string id);
        public Task<User> GetUserById(string id);
        public Task<User> Login(string username, string password);
    }
}

