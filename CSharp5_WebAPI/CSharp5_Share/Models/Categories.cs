using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class Categories
    {
        [Key]
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
    }
}
