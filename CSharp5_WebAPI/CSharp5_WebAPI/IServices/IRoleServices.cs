using CSharp5_Share.Models;

namespace CSharp5_WebAPI.IServices
{
    public interface IRoleServices
    {
        public Task<IEnumerable<Role>> GetAllRole();
        public Task<Role> PostRole(Role role);
        public Task<Role> PutRole(string id, string rolename);
        public Task DeleteRole(string id);
        public Task<Role> GetRoleById(string id);
    }
}
