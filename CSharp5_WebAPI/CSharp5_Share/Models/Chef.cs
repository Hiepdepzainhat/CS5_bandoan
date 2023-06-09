using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class Chef
    {
        [Key]
        public Guid ChefID { get; set; }
        public string? ChefName { get; set; }
        public string? ChefDescription { get; set; }
    }
}
