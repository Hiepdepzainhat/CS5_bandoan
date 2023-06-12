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

        public async Task<User> PutUser(User u)
        {
            var users = _context.Users.Find(u.UserID);
            users.NationalID =u.NationalID;
            users.RoleID = u.RoleID;
            users.Name = u.Name;
            users.UserName = u.UserName;
            users.PassWord = u.PassWord;
            users.PhoneNumber = u.PhoneNumber;
            users.Address = u.Address;
            users.DateOfBirth = u.DateOfBirth;
            users.Sex = u.Sex;
            users.ImgUser = u.ImgUser;
            _context.Users.Update(users);
            await _context.SaveChangesAsync();
            return users;

        }
    }
}
