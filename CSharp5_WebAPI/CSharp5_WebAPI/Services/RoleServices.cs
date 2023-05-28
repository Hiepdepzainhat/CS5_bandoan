using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp5_WebAPI.Services
{
    public class RoleServices : IRoleServices
    {
        private CS5_DbContext _context;
        public RoleServices(CS5_DbContext context)
        {
            _context = context;
        }
        public async Task DeleteRole(string id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.RoleID == Guid.Parse(id));
             _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Role>> GetAllRole()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(string id)
        {
           return _context.Roles.FirstOrDefault(x => x.RoleID == Guid.Parse(id));
        }

        public async Task<Role> PostRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> PutRole(string id, Role role)
        {
            var roles = _context.Roles.FirstOrDefault(x => x.RoleID == Guid.Parse(id));
            roles.RoleName = role.RoleName;
            _context.Roles.Update(roles);
            await _context.SaveChangesAsync();
            return roles; 

        }
    }
}
