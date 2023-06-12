using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class Role
    {
        [Key]
        public Guid RoleID { get; set; }
        public string? RoleName { get; set; }
        public virtual IEnumerable<User>? Users { get; set; }
    }
}
