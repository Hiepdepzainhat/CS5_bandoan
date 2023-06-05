namespace CSharp5_Share.Models
{
    public class Role
    {
        public Guid RoleID { get; set; }
        public string  RoleName { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
