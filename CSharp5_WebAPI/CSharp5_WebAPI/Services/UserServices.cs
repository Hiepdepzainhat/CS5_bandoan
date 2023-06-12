using CSharp5_Share.Models;
using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class UserServices : IUserServices
    {
        private CS5_DbContext _context;
        public UserServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteUser(string id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserID == Guid.Parse(id));
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(x => x.UserID == Guid.Parse(id));
        }

        public async Task<User> Login(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == username && x.PassWord == password);
        }

        public async Task<User> PostUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> PutUser(string id, string name, string username, Guid nationalID,string password, string phonenumber, string address, DateTime dateofbirthday, int sex, string imguser)
        {
            var users = _context.Users.FirstOrDefault(x => x.UserID == Guid.Parse(id));
            users.NationalID = nationalID;
            users.Name = name;
            users.UserName = username;
            users.PassWord = password;
            users.PhoneNumber = phonenumber;
            users.Address = address;
            users.DateOfBirth = dateofbirthday;
            users.Sex = sex;
            users.ImgUser = imguser;
            _context.Users.Update(users);
            await _context.SaveChangesAsync();
            return users;

        }
    }
}
